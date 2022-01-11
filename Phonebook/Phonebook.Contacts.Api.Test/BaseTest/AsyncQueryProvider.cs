namespace Phonebook.Contacts.Api.Test.BaseTest
{
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class AsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public AsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new AsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new AsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default)
        {
            var resultadoTipo = typeof(TResult).GetGenericArguments()[0];
            var ejecucionResultado = typeof(IQueryProvider)
                                        .GetMethod(
                                            name: nameof(IQueryProvider.Execute),
                                            genericParameterCount: 1,
                                            types: new[] { typeof(Expression) }
                                        )
                                        .MakeGenericMethod(resultadoTipo)
                                        .Invoke(this, new[] { expression });

            return (TResult)typeof(Task).GetMethod(nameof(Task.FromResult))?
                    .MakeGenericMethod(resultadoTipo).Invoke(null, new[] { ejecucionResultado });

        }
    }
}