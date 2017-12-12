using System.Web.Mvc;
using TotallyNotRobots.Movies.Web.ApiClient;
using TotallyNotRobots.Movies.Web.ApiClient.Models;

namespace TotallyNotRobots.Movies.Web.Controllers
{
    [RoutePrefix("movies/{movieID}/reviews")]
    public class ReviewsController : Controller
    {
        private readonly IApi _api;

        public ReviewsController(IApi api)
        {
            _api = api;
        }

        [Route("new", Name = "NewReview")]
        public ActionResult Create(int movieID)
        {
            ViewBag.MovieID = movieID;
            return View();
        }

        [Route("new")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int movieID, [Bind(Include = "ID,Comments")] Review review)
        {
            ViewBag.MovieID = movieID;
            if (ModelState.IsValid)
            {
                _api.Reviews.Post(movieID, review);
                return RedirectToAction("Details", "Movies", new { id = movieID });
            }

            return View(review);
        }

        // GET: Reviews/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Review review = db.Reviews.Find(id);
        //    if (review == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(review);
        //}

        //// POST: Reviews/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Comments")] Review review)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(review).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(review);
        //}

        // GET: Reviews/Delete/5
        //public ActionResult Delete(int movieID, int reviewID)
        //{
        //    var review = _api.Reviews.GetReview(movieID, reviewID);
        //    if (review == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(review);
        //}

        //// POST: Reviews/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int movieID, int reviewID)
        //{
        //    _api.Reviews.Delete(movieID, reviewID);
        //    return RedirectToAction("Index");
        //}

    }
}
