using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace WebApplication3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Guest newGuest = new Guest();
                bool isOk = TryUpdateModel(newGuest, new FormValueProvider(ModelBindingExecutionContext));
                if(isOk)
                {
                    GuestRepository.getInstance().AddResponse(newGuest);
                    if (newGuest.WillAttend.HasValue && newGuest.WillAttend.Value)
                        Response.Redirect("yes.html");
                    else
                        Response.Redirect("no.html");
                }
            }
        }
    }
}