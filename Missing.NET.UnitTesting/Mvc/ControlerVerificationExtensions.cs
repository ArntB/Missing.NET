using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Missing.NET.UnitTesting.Mvc
{
    /// <summary>
    /// This extension is based on ideas from Torkel Ödegaard.
    /// http://www.codinginstinct.com/2008/08/actionresult-method-extensions-for-unit.html
    /// His Ideas are again based on the Suteki Shop.
    /// http://code.google.com/p/sutekishop/
    /// </summary>
    public static class ControlerVerificationExtensions
    {
        public static ViewResult ReturnsViewResult(this ActionResult result)
        {
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult,
                "Expected result of type: {0}, but was: {1}"
                .With(typeof(ViewResult),result.GetType()));
            return viewResult;
        }
        public static PartialViewResult ReturnsPartialViewResult(this ActionResult result)
        {
            var viewResult = result as PartialViewResult;
            Assert.IsNotNull(viewResult,
                "Expected result of type: {0}, but was: {1}"
                .With(typeof(PartialViewResult), result.GetType()));
            return viewResult;
        }

        public static ViewResultBase ForView(this ViewResultBase result, string viewName)
        {
            Assert.AreEqual(viewName, result.ViewName,
                            "Expected view named: {0}, but was: {1}"
                            .With(viewName, result.ViewName));
            return result;
        }

        public static ViewResult ForMaster(this ViewResult result, string masterName)
        {
            Assert.AreEqual(masterName, result.MasterName);
            return result;
        }

        public static ContentResult ReturnsContentResult(this ActionResult result)
        {
            var contentResult = result as ContentResult;
            Assert.IsNotNull(contentResult);
            return contentResult;
        }

        public static TViewModel WithViewModel<TViewModel>(this ViewResultBase result) where TViewModel : class
        {
            if(result.ViewData.Model == null) Assert.Fail("View model was null");
            TViewModel viewData = result.ViewData.Model as TViewModel;
            Assert.IsNotNull(viewData, "Expected view model of type: {0}, but was: {1}"
                                           .With(typeof (TViewModel), result.ViewData.Model.GetType()));
            return viewData;
        }

        public static TType WithViewData<TType>(this ViewResultBase result, string key) where TType : class
        {
            object viewDataObject = result.WithViewData(key);
            
            TType viewData = viewDataObject as TType;
            Assert.IsNotNull(viewData,
                "Expected view data named \"{0}\" of type <{1}> but actual type was <{2}>."
                .With(key, typeof (TType), viewDataObject.GetType()));
            return viewData;
        }
        public static object WithViewData(this ViewResultBase result, string key)
        {
            Assert.IsTrue(result.ViewData.ContainsKey(key),
                "Expected view data named \"{0}\" not found".With(key));
            return result.ViewData[key];
        }       

    }
}