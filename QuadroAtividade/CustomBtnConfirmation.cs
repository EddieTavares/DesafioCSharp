namespace System.Web.Mvc.Html
{
  public static class BtnConfirmation
    {

        public static MvcHtmlString CustomBtnConfirmation<TModel>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper,
                string pBtnCaption, 
                string pMessageHeader, 
                string pMessageConfirmation, 
                object pHtmlAttributes, 
                string pOk, 
                string pCancel)
        {
            var builder = new TagBuilder("button");
            builder.InnerHtml = pBtnCaption;
            builder.Attributes["type"] = "button";
            builder.Attributes["data-target"] ="#modalConfirma";
            builder.Attributes["data-toggle"] = "modal";
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(pHtmlAttributes));

            var modalConfirma = builder.ToString() + Environment.NewLine +
                $" <div class='modal' id='modalConfirma'>                                                                    " + Environment.NewLine +
                $"     <div class='modal-dialog'>                                                                            " + Environment.NewLine +
                $"         <div class='modal-content'>                                                                       " + Environment.NewLine +
                $"             <div class='modal-header'>                                                                    " + Environment.NewLine +
                $"                 <h4 class='modal-title'>                                                                  " + Environment.NewLine +
                $"                     { pMessageHeader }                                                                    " + Environment.NewLine +
                $"                 </h4>                                                                                     " + Environment.NewLine +
                $"                 <button type = 'button' class='close' data-dismiss='modal'>&times;</button>               " + Environment.NewLine +
                $"             </div>                                                                                        " + Environment.NewLine +
                $"                                                                                                           " + Environment.NewLine +
                $"             <!-- Modal body -->                                                                           " + Environment.NewLine +
                $"             <div class='modal-body'>                                                                      " + Environment.NewLine +
                $"                  { pMessageConfirmation }                                                                 " + Environment.NewLine +
                $"             </div>                                                                                        " + Environment.NewLine +
                $"                                                                                                           " + Environment.NewLine +
                $"             <!-- Modal footer -->                                                                         " + Environment.NewLine +
                $"             <div class='modal-footer'>                                                                    " + Environment.NewLine +
                $"                 <input type = 'submit' value='{ pOk }' class='btn btn-default' />                         " + Environment.NewLine +
                $"                 <button type = 'button' class='btn btn-default' data-dismiss='modal'>{ pCancel }</button> " + Environment.NewLine +
                $"             </div>                                                                                        " + Environment.NewLine +
                $"         </div>                                                                                            " + Environment.NewLine +
                $"     </div>                                                                                                " + Environment.NewLine +
                $" </div>                                                                                                    " + Environment.NewLine;

            return MvcHtmlString.Create(modalConfirma);
        }

        public static MvcHtmlString CustomBtnConfirmation<TModel>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper,
            string pBtnCaption,
            string pMessageHeader,
            string pMessageConfirmation,
            object pHtmlAttributes)
        {
            return (CustomBtnConfirmation(htmlHelper, pBtnCaption, pMessageHeader, pMessageConfirmation, pHtmlAttributes, "Sim", "Não"));
        }

        public static MvcHtmlString CustomBtnConfirmation<TModel>(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper,
            string pBtnCaption,
            string pMessageHeader,
            string pMessageConfirmation)
        {
            return (CustomBtnConfirmation(htmlHelper, pBtnCaption, pMessageHeader, pMessageConfirmation, new { @class = "btn btn-info" }, "Sim", "Não"));
        }
    }
   
} 
