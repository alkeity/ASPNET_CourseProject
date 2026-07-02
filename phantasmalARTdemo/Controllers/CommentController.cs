using Microsoft.AspNetCore.Mvc;
using PhantasmalARTdemo.Models.Containers;
using PhantasmalARTdemo.Services;

namespace PhantasmalARTdemo.Controllers
{
    public class CommentController : Controller
    {
        private IArtCommentService _artCommentService;
        private IHttpContextAccessor _contextAccessor;

        public CommentController(IArtCommentService artCommentService, IHttpContextAccessor contextAccessor)
        {
            _artCommentService = artCommentService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost]
        [Route("comment/new")]
        public IActionResult AddArtComment(ArtDisplayView pageModel, string artist, Guid externalUUID)
        {
            string? username = _contextAccessor.HttpContext.Session.GetString("UserName");

            if (!string.IsNullOrEmpty(username)) {
                // get comment from form and save it to db
                pageModel.CommentForm.Entity.Author = username;
                _artCommentService.NewComment(pageModel.CommentForm.Entity, externalUUID);
            }

            // return to art
            return RedirectToAction("ArtDisplay", "Art", new { username = artist, artID = externalUUID });
        }
    }
}
