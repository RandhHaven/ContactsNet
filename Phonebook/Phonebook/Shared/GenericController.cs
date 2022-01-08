namespace Phonebook.Api.Contacts.Shared
{
    using Microsoft.AspNetCore.Mvc;

    public class GenericController<TUIServiceWork> : ControllerBase
    {
        #region Properties

        protected TUIServiceWork UIService { get; private set; }

        #endregion

        #region Builds
        protected GenericController(TUIServiceWork uiService)
        {
            this.UIService = uiService;
        }
        #endregion

        #region Initialization Methods
        public virtual void OnInitialize() { }

        protected virtual void InitializeBehavior()
        {
        }

        protected virtual void InitializeTempDataValues()
        {
        }

        #endregion

    }
}
