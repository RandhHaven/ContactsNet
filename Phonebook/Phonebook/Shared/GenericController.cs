namespace Phonebook.Api.Contacts.Shared
{
    using Microsoft.AspNetCore.Mvc;

    public class GenericController<TUIService> : ControllerBase
    {
        #region Properties

        protected TUIService UIService { get; private set; }

        #endregion

        #region Builds
        protected GenericController(TUIService uiService)
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
