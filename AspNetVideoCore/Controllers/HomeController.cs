using AspNetVideoCore.Entities;
using AspNetVideoCore.Services;
using AspNetVideoCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetVideoCore.Controllers
{
	public class HomeController : Controller
	{
		private IVideoData _videos;

		public HomeController(IVideoData videos)
		{
			_videos = videos;
		}

		public ViewResult Index() // ViewResult returns a video from the controller. Can also be an ObjectResult (e.g. a json file)
		{
			var model = _videos.GetAll().Select(video =>
				new VideoViewModel
				{
					Id = video.Id,
					Title = video.Title,
					Genre = video.Genre.ToString(),
					ProductionCompany = video.ProductionCompany
				});
			return View(model);
		}

		public IActionResult Details(int id)
		{
			var model = _videos.Get(id);
			if (model == null)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View(new VideoViewModel
				{
					Id = model.Id,
					Title = model.Title,
					Genre = model.Genre.ToString(),
					ProductionCompany = model.ProductionCompany
				});
			}
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(VideoEditViewModel model)
		{
			if (ModelState.IsValid)
			{
				var video = new Video
				{
					Title = model.Title,
					Genre = model.Genre,
					ProductionCompany = model.ProductionCompany
				};

				_videos.Add(video);
				return RedirectToAction("Details", new { id = video.Id });
			}

			return View();
		}
	}
}
