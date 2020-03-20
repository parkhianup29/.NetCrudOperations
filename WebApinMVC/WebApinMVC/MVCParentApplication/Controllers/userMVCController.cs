using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCParentApplication.Models;
using System.Net.Http;

namespace MVCParentApplication.Controllers
{
    public class userMVCController : Controller
    {
        // GET: userMVC
        public ActionResult Index()
        {
            IEnumerable<MVCuserModel> userlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("usercontactdetails").Result;
            userlist = response.Content.ReadAsAsync<IEnumerable<MVCuserModel>>().Result;
            return View(userlist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new MVCuserModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("UserContactDetails/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCuserModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(MVCuserModel user)
        {
            if (user.UserContactDetailUID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("UserContactDetails", user).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("UserContactDetails/" + user.UserContactDetailUID, user).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("UserContactDetails/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}