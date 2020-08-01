using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ForAfterwind.Domain;
using ForAfterwind.Models;
using ImageMagick;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ForAfterwind.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private AppDbContext db;

        IWebHostEnvironment _appEnvironment;

        public AdminController(AppDbContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        public async Task<IActionResult> ProgressBars()
        {
            return View(await db.ProgressBars.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Greetings()
        {
            return View(await db.Greetings.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Video()
        {
            return View(await db.VideoAlbums.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Audio()
        {
            return View(await db.Releases.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Photo()
        {
            return View(await db.PhotoAlbums.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Musician()
        {
            return View(await db.Musicians.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Blog()
        {
            return View(await db.Posts.AsNoTracking().ToListAsync());    
        }

        // CRUD

        //PartialViews

        [HttpGet]
        public async Task<PartialViewResult> _partialSkills(int? id)
        {
            if (id == null)
            {
                return PartialView();
            }
            return PartialView(await db.Skills.Where(skill => skill.MusicianId == id).ToListAsync());
        }

        [HttpGet]
        public async Task<PartialViewResult> _socialLinks(int? id)
        {
            if (id == null)
            {
                return PartialView();
            }
            return PartialView(await db.SocialLinks.Where(link => link.MusicianId == id).ToListAsync());
        }

        [HttpGet]
        public async Task<PartialViewResult> _partialSongs(int? id)
        {
            if (id == null)
            {
                return PartialView();
            }
            return PartialView(await db.Songs.Where(song => song.ReleaseId == id).ToListAsync());
        }

        [HttpGet]
        public async Task<PartialViewResult> _partialVideos(int? id)
        {
            if (id == null)
            {
                return PartialView();
            }
            return PartialView(await db.Videos.Where(video => video.VideoAlbumId == id).ToListAsync());
        }

        [HttpGet]
        public async Task<PartialViewResult> _partialPhotos(int? id)
        {
            if (id == null)
            {
                return PartialView();
            }
            return PartialView(await db.Photos.Where(photo => photo.PhotoAlbumId == id).ToListAsync());
        }

        public async Task<PartialViewResult> _AlbumStages(int? id)
        {
            return PartialView(await db.AlbumStages.Where(stage => stage.ProgressBarId == id).ToListAsync());
        }

        public PartialViewResult _Picture(IFormFile uploadedFile)
        {
            return PartialView(uploadedFile);
        }

        //Edit

        [HttpGet]
        public async Task<IActionResult> EditGreeting(int? id)
        {
            return View(await db.Greetings.FirstOrDefaultAsync(greeting => greeting.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> EditGreeting(Greeting greeting, IFormFile uploadedFile)
        {
            if(uploadedFile != null)
            {
                greeting.Cover = await FileToByteAsync(uploadedFile);
            }
            db.Greetings.Update(greeting);
            await db.SaveChangesAsync();
            return RedirectToAction("Greetings");
        }

        [HttpGet]
        public async Task<IActionResult> EditProgressBar(int? id)
        {
            return View(await db.ProgressBars.FirstOrDefaultAsync(el => el.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> EditProgressBar(ProgressBar progressBar, System.Drawing.Color favcolor)
        {
            if(favcolor.IsKnownColor)
            {
                progressBar.Color = favcolor.Name;
            }
            else 
            {
                progressBar.Color = GetRGBFromARGB(favcolor.Name);
            }
            

            db.ProgressBars.Update(progressBar);
            await db.SaveChangesAsync();
            return RedirectToAction("ProgressBars");
        }

        [HttpGet]
        public async Task<IActionResult> EditAlbumStage(int? id)
        {
            return View(await db.AlbumStages.FirstOrDefaultAsync(el => el.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> EditAlbumStage(AlbumStage albumStage)
        {
            db.AlbumStages.Update(albumStage);
            await db.SaveChangesAsync();
            return RedirectToAction("AlbumStages");
        }

        public async Task<PartialViewResult> EditLink(int? id, string name, string path)
        {
            SocialLink link = await db.SocialLinks.FirstOrDefaultAsync(x => x.Id == id);
            link.Name = name;
            link.Path = path;
            db.SocialLinks.Update(link);
            await db.SaveChangesAsync();
            return await _socialLinks(link.MusicianId);
        }

        [HttpGet]
        public async Task<IActionResult> EditMusician(int? id)
        {
            if (id != null)
            {
                Musician musician = await db.Musicians
                    .Include(x => x.Skills)
                    .Include(x => x.SocialLinks)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (musician != null)
                {
                    return View(musician);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditMusician(Musician musician, IFormFile uploadedFile)
        {

            if (uploadedFile != null)
            {
                string path = "/img/Musicians/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(
                    _appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                musician.Photo = path;
            }
            db.Musicians.Update(musician);
            await db.SaveChangesAsync();
            return RedirectToAction("Musician");
        }

        [HttpGet]
        public async Task<IActionResult> EditRelease(int? id)
        {
            Release release = new Release();
            if (id != null)
            {
                release = await db.Releases.
                    Include(x => x.Songs).
                    FirstOrDefaultAsync(x => x.Id == id);


                if (release != null)
                {
                    return View(release);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditRelease(Release release, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = $"/Media/Albums/";
                string subPath = $"{release.Name}/";

                if(!Directory.Exists(path + subPath))
                {
                    CreateDirectory(path, subPath);
                }

                using (var fileStream = new FileStream(
                    _appEnvironment.WebRootPath + path + subPath + uploadedFile.FileName, FileMode.Create))
                    {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                release.PathToCover = path + subPath + uploadedFile.FileName;
            }
            db.Releases.Update(release);
            await db.SaveChangesAsync();
            return RedirectToAction("Audio");
        }

        [HttpGet]
        public async Task<IActionResult> EditVideoAlbum(int? id)
        {
            if (id != null)
            {
                var videoAlbum = await db.VideoAlbums.
                    Include(x => x.Videos).
                    FirstOrDefaultAsync(x => x.Id == id);

                if (videoAlbum != null)
                {
                    return View(videoAlbum);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditVideoAlbum(VideoAlbum videoAlbum, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = $"/Media/Video/{videoAlbum.Name}/{uploadedFile.FileName}";
                using (var fileStream = new FileStream(
                    _appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                videoAlbum.PathToCover = path;
            }
            db.VideoAlbums.Update(videoAlbum);
            await db.SaveChangesAsync();
            return RedirectToAction("Video");
        }

        [HttpGet]
        public async Task<IActionResult> EditPhotoAlbum(int? id)
        {
            if (id != null)
            {
                var photoAlbum = await db.PhotoAlbums.
                    Include(x => x.Photos).
                    FirstOrDefaultAsync(x => x.Id == id);

                if (photoAlbum != null)
                {
                    return View(photoAlbum);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditPhotoAlbum(PhotoAlbum photoAlbum, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = $"/Media/Photo albums/{photoAlbum.Name}/{uploadedFile.FileName}";
                using (var fileStream = new FileStream(
                    _appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                photoAlbum.PathToCover = path;
            }
            db.PhotoAlbums.Update(photoAlbum);
            await db.SaveChangesAsync();
            return RedirectToAction("Photo");
        }

        [HttpGet]
        public async Task<IActionResult> EditPost(int? id)
        {
            return View(await db.Posts.FirstOrDefaultAsync(post => post.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(Post newPost, IFormFile uploadedFile)
        {
            var oldPost = await db.Posts.FirstOrDefaultAsync(post => post.Id == newPost.Id);

            oldPost.Title = newPost.Title;
            oldPost.ShortDescription = newPost.ShortDescription;
            oldPost.Description = newPost.Description;
            oldPost.Modified = DateTime.Now;
            oldPost.Meta = newPost.Meta;
            oldPost.Tags = newPost.Tags;
            oldPost.UrlSlug = GetUrlSlug(newPost.Title, newPost.Id);

            if(uploadedFile != null)
            {
                oldPost.CoverMimeType = uploadedFile.ContentType;
                oldPost.Cover = await FileToByteAsync(uploadedFile);
                oldPost.CoverThumbnail = await ResizeImageAsync(uploadedFile);

            }

            db.Posts.Update(oldPost);
            await db.SaveChangesAsync();

            return RedirectToAction("Blog");
        }

        //Create

        [HttpGet]
        public IActionResult CreateGreeting()
        {
            return View(new Greeting());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGreeting(Greeting greeting, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                greeting.Cover = await FileToByteAsync(uploadedFile);
            }
            await db.Greetings.AddAsync(greeting);
            await db.SaveChangesAsync();
            return RedirectToAction("Greetings");
        }

        [HttpGet]
        public IActionResult CreateProgressBar()
        {
            ProgressBar progressBar = new ProgressBar();
            return View(progressBar);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgressBar(ProgressBar progressBar)
        {
            await db.ProgressBars.AddAsync(progressBar);
            await db.SaveChangesAsync();
            return RedirectToAction("ProgressBars");
        }

        [HttpGet]
        public IActionResult CreateAlbumStage()
        {
            AlbumStage albumStage = new AlbumStage();
            return View(albumStage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbumStage(int id, string name, int progress)
        {
            //if(await db.AlbumStages.Where(stage => stage.ProgressBarId == id).CountAsync() > 4)
            //    return StatusCode()

            AlbumStage albumStage = new AlbumStage();
            albumStage.Name = name;
            albumStage.Progress = progress;
            albumStage.ProgressBarId = id;
            await db.AlbumStages.AddAsync(albumStage);
            await db.SaveChangesAsync();
            return StatusCode(200);
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            Post post = new Post();
            
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post, IFormFile uploadedFile)
        {
            post.PostedOn = DateTime.Now;
            post.Modified = DateTime.Now;
            post.UrlSlug = GetUrlSlug(post.Title, post.Id);

            if(uploadedFile != null)
            {
                post.CoverMimeType = uploadedFile.ContentType;
                post.Cover = await FileToByteAsync(uploadedFile);
                post.CoverThumbnail = await ResizeImageAsync(uploadedFile);
            }
            
            db.Posts.Add(post);
            await db.SaveChangesAsync();

            return RedirectToAction("Blog");
        }

        [HttpGet]
        public IActionResult CreateMusician()
        {
            Musician musician = db.Musicians.FirstOrDefault(x => x.Name == "New");
            

            if (musician != null)
            {
                musician.Name = "New";
                db.Musicians.Add(musician);
                db.SaveChanges();
            }

            return View(musician);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMusician(Musician musician, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/img/Musicians/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(
                    _appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                musician.Photo = path;
            }
            db.Musicians.Update(musician);
            await db.SaveChangesAsync();
            return RedirectToAction("Musician");
        }

        [HttpGet]
        public IActionResult CreateRelease()
        {
            Release release = new Release();
            release = db.Releases.FirstOrDefault(x => x.Name == "New");
            if (release != null)
            {
                release.Name = "New";
                db.Releases.Add(release);
                db.SaveChanges();
            }
            return View(release);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRelease(Release release, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = $"/Media/Albums/";
                string subPath = $"{release.Name}/";

                CreateDirectory(path, subPath);

                using (var fileStream = new FileStream(
                    _appEnvironment.WebRootPath + path + subPath + uploadedFile.FileName, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                release.PathToCover = path + subPath + uploadedFile.FileName;
            }
            db.Releases.Add(release);
            await db.SaveChangesAsync();
            return RedirectToAction("Audio");
        }

        [HttpGet]
        public IActionResult CreateVideoAlbum()
        {
            VideoAlbum videoAlbum = new VideoAlbum();
            videoAlbum = db.VideoAlbums.FirstOrDefault(x => x.Name == "New");
            if (videoAlbum != null)
            {
                videoAlbum.Name = "New";
                db.VideoAlbums.Add(videoAlbum);
                db.SaveChanges();
            }
            return View(videoAlbum);
        }
        [HttpPost]
        public async Task<IActionResult> CreateVideoAlbum(VideoAlbum videoAlbum, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = $"/Media/Video/";
                string subPath = $"{videoAlbum.Name}/";

                CreateDirectory(path, subPath);

                using (var fileStream = new FileStream(
                    _appEnvironment.WebRootPath + path + subPath + uploadedFile.FileName, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                videoAlbum.PathToCover = path + subPath + uploadedFile.FileName;
            }
            db.VideoAlbums.Add(videoAlbum);
            await db.SaveChangesAsync();
            return RedirectToAction("Video");
        }


        [HttpGet]
        public IActionResult CreatePhotoAlbum()
        {
            PhotoAlbum photoAlbum = new PhotoAlbum();
            photoAlbum = db.PhotoAlbums.FirstOrDefault(x => x.Name == "New");
            if (photoAlbum != null)
            {
                photoAlbum.Name = "New";
                db.PhotoAlbums.Add(photoAlbum);
                db.SaveChanges();
            }
            return View(photoAlbum);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhotoAlbum(PhotoAlbum photoAlbum, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = $"/Media/Photo albums/";
                string subPath = $"{photoAlbum.Name}/";

                CreateDirectory(path, subPath);

                using (var fileStream = new FileStream(
                    _appEnvironment.WebRootPath + path + subPath + uploadedFile.FileName, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                photoAlbum.PathToCover = path + subPath + uploadedFile.FileName;
            }
            db.PhotoAlbums.Add(photoAlbum);
            await db.SaveChangesAsync();
            return RedirectToAction("Photo");
        }


        [HttpPost]
        public async Task<StatusCodeResult> CreateSkill(int? id, string name)
        {
            Skill skill = new Skill();
            skill.Name = name;
            skill.MusicianId = id;
            skill.Musician = await db.Musicians.FirstOrDefaultAsync(musician => musician.Id == id);

            await db.Skills.AddAsync(skill);
            await db.SaveChangesAsync();

            return StatusCode(200);
        }

        [HttpPost]
        public async Task<StatusCodeResult> CreateLink(int? id, string name, string url)
        {
            SocialLink link = new SocialLink();
            link.Name = name.ToLower();
            link.MusicianId = id;
            link.Path = url;
            link.Musician = await db.Musicians.FirstOrDefaultAsync(musician => musician.Id == id);
            await db.SocialLinks.AddAsync(link);
            await db.SaveChangesAsync();

            return StatusCode(200);
        }

        [HttpPost]
        public async Task<StatusCodeResult> AddVideo(int? id, IFormFile uploadedFile)
        {
            VideoAlbum videoAlbum = await db.VideoAlbums.FirstOrDefaultAsync(videoAlbum => videoAlbum.Id == id);
            Video video = new Video();
            string path = $"/Media/Video/{videoAlbum.Name}/{uploadedFile.FileName}";

            using (FileStream fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create, FileAccess.Write))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            video.Name = uploadedFile.FileName;
            video.VideoAlbumId = id;
            video.PathToVideo = path;
            video.VideoAlbum = videoAlbum;
            await db.Videos.AddAsync(video);
            await db.SaveChangesAsync();

            return StatusCode(200);
            
        }

        [HttpPost]
        public async Task<StatusCodeResult> AddPhotos(int? id, IEnumerable<IFormFile> files)
        {
            PhotoAlbum photoAlbum = await db.PhotoAlbums.FirstOrDefaultAsync(album => album.Id == id);

            foreach (var file in files)
            {
                string path = $"/Media/Photo albums/{photoAlbum.Name}/{file.FileName}";
                using (FileStream fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fileStream);
                }
                Photo photo = new Photo();
                photo.PathToPhoto = path;
                photo.PhotoAlbum = photoAlbum;
                photo.PhotoAlbumId = id;
                await db.Photos.AddAsync(photo);
            }
            await db.SaveChangesAsync();

            return StatusCode(200);
        }

        [HttpPost]
        public async Task<StatusCodeResult> AddSongs(int? id, IEnumerable<IFormFile> uploadedFiles)
        {

            if (uploadedFiles != null)
            {
                Release release = await db.Releases.FirstOrDefaultAsync(release => release.Id == id);

                foreach(var file in uploadedFiles)
                {
                    string path = $"/Media/Albums/{release.Name}/" + file.FileName;

                    using (var fileStream = new FileStream(
                        _appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    Song song = new Song();
                    song.Name = file.FileName;
                    song.PathToSong = path;
                    song.ReleaseId = id;
                    song.Release = release;
                    string extention = Path.GetExtension(file.FileName);
                    if (extention == ".mp3" || extention == ".aac" || extention == ".wav")
                    {
                        song.Type = TypesOfReleases.Audio;
                    }
                    else
                    {
                        song.Type = TypesOfReleases.Video;
                    }
                    
                    await db.Songs.AddAsync(song);
                }
                await db.SaveChangesAsync();

                
            }
            return StatusCode(200);

        }



        // Delete

        [HttpGet]
        [ActionName("DeleteMusician")]
        public async Task<IActionResult> ConfirmDeleteMusician(int? id)
        {
            if (id != null)
            {
                Musician musician = await db.Musicians.FirstOrDefaultAsync(p => p.Id == id);
                if (musician != null)
                    return View(musician);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteMusician(int? id)
        {
            if (id != null)
            {
                Musician musician = await db.Musicians.FirstOrDefaultAsync(p => p.Id == id);
                if (musician != null)
                {

                    DeleteRelatedEntities(id);
                    db.Musicians.Remove(musician);
                    await db.SaveChangesAsync();
                    DeleteFileFromDirectory(musician.Photo);
                    return RedirectToAction("Musician");
                    
                }
            }
            return NotFound();
        }
        
        public async Task<IActionResult> DeleteRelease(int? id)
        {
            if (id != null)
            {
                Release release = await db.Releases.FirstOrDefaultAsync(x => x.Id == id);
                
                if (release != null)
                {
                    foreach(var song in db.Songs.Where(x => x.ReleaseId == id))
                    {
                        db.Songs.Remove(song);
                        DeleteFileFromDirectory(song.PathToSong);
                    }
                    db.Releases.Remove(release);
                    await db.SaveChangesAsync();
                    DeleteDirectory(release.PathToCover);
                    return RedirectToAction("Audio");
                    
                }
            }
            return NotFound();
        }
        
        public async Task<IActionResult> DeleteVideoAlbum(int? id)
        {
            if (id != null)
            {
                VideoAlbum videoAlbum = await db.VideoAlbums.FirstOrDefaultAsync(x => x.Id == id);
                if (videoAlbum != null)
                {
                    foreach (var video in db.Videos.Where(x => x.VideoAlbumId == id))
                    {
                        db.Videos.Remove(video);
                        DeleteFileFromDirectory(video.PathToVideo);
                    }
                    db.VideoAlbums.Remove(videoAlbum);
                    await db.SaveChangesAsync();
                    DeleteDirectory(videoAlbum.PathToCover);
                    return RedirectToAction("Video");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> DeletePhotoAlbum(int? id)
        {
            if (id != null)
            {
                PhotoAlbum photoAlbum = await db.PhotoAlbums.FirstOrDefaultAsync(x => x.Id == id);
                if (photoAlbum != null)
                {
                    foreach (var photo in db.Photos.Where(x => x.PhotoAlbumId == id))
                    {
                        db.Photos.Remove(photo);
                        DeleteFileFromDirectory(photo.PathToPhoto);
                    }
                    db.PhotoAlbums.Remove(photoAlbum);
                    await db.SaveChangesAsync();
                    DeleteDirectory(photoAlbum.PathToCover);
                    return RedirectToAction("Photo");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> DeletePost(int? id)
        {
            var deletingPost = await db.Posts.FirstOrDefaultAsync(post => post.Id == id);
            db.Posts.Remove(deletingPost);
            await db.SaveChangesAsync();
            return RedirectToAction("Blog");
        }

        public async Task<IActionResult> DeleteProgressBar(int? id)
        {
            db.ProgressBars.Remove(await db.ProgressBars.FirstOrDefaultAsync(progressBar => progressBar.Id == id));
            await db.SaveChangesAsync();
            return RedirectToAction("ProgressBars");
        }

        public async Task<IActionResult> DeleteGreeting(int? id)
        {
            db.Greetings.Remove(await db.Greetings.FirstOrDefaultAsync(greeting => greeting.Id == id)); 
            await db.SaveChangesAsync();
            return RedirectToAction("Greetings");
        }


        public async Task<StatusCodeResult> DeleteSkill(int? id)
        {
            Skill skill = await db.Skills.FirstOrDefaultAsync(skill => skill.Id == id);
            db.Skills.Remove(skill);
            await db.SaveChangesAsync();

            return StatusCode(200);
        }
        
        public async Task<StatusCodeResult> DeleteLink(int? id)
        {
            SocialLink link = await db.SocialLinks.FirstOrDefaultAsync(link => link.Id == id);
            db.SocialLinks.Remove(link);
            await db.SaveChangesAsync();
            return StatusCode(200);
        }
        
        public async Task<StatusCodeResult> DeleteSong(int? id)
        {
            Song song = await db.Songs.FirstOrDefaultAsync(song => song.Id == id);
            db.Songs.Remove(song);
            await db.SaveChangesAsync();
            DeleteFileFromDirectory(song.PathToSong);

            return StatusCode(200);
        }
        
        public async Task<StatusCodeResult> DeleteVideo(int? id)
        {
            Video video = await db.Videos.FirstOrDefaultAsync(video => video.Id == id);
            db.Videos.Remove(video);
            await db.SaveChangesAsync();
            DeleteFileFromDirectory(video.PathToVideo);

            return StatusCode(200);
        }
        
        public async Task<StatusCodeResult> DeletePhoto(int? id)
        {
            Photo photo = await db.Photos.FirstOrDefaultAsync(photo => photo.Id == id);
            db.Photos.Remove(photo);
            await db.SaveChangesAsync();
            DeleteFileFromDirectory(photo.PathToPhoto);

            return StatusCode(200);
        }

        public async Task<StatusCodeResult> DeleteAlbumStage(int? id)
        {
            db.AlbumStages.Remove(await db.AlbumStages.FirstOrDefaultAsync(stage => stage.Id == id));
            await db.SaveChangesAsync();
            return StatusCode(200);
        }

        //Other

        void DeleteRelatedEntities(int? id)
        {
            db.SocialLinks.RemoveRange(db.SocialLinks.Where(x => x.MusicianId == id));
            db.Skills.RemoveRange(db.Skills.Where(x => x.MusicianId == id));
            db.SaveChanges();
        }

        void CreateDirectory(string path, string subPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(
                $"{_appEnvironment.WebRootPath}{path}");

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            directoryInfo.CreateSubdirectory(subPath);
        }

        void DeleteFileFromDirectory(string path)
        {
            if (System.IO.File.Exists(Path.Combine(_appEnvironment.WebRootPath + path)))
                System.IO.File.Delete(Path.Combine(_appEnvironment.WebRootPath + path));
        }

        void DeleteDirectory(string path)
        {
            if(path != null)
            {
                string directoryName = Path.GetDirectoryName(path);
                string fullPath = _appEnvironment.WebRootPath + directoryName;

                if (Directory.Exists(fullPath))
                    Directory.Delete(fullPath, true);
            }

        }

        protected async Task<byte[]> FileToByteAsync(IFormFile file)
        {
            byte[] image = null;
            if (file != null)
            {
                using (var fileStream = file.OpenReadStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await fileStream.CopyToAsync(memoryStream);
                        image = memoryStream.ToArray();
                    }

                }
            }
            return image;
        }

        protected async Task<byte[]> ResizeImageAsync(IFormFile image)
        {
            if (image.Length > 0)
            {
                using (MagickImage thumbnail = new MagickImage(await FileToByteAsync(image)))
                {
                    thumbnail.Resize(250, 150);
                    return thumbnail.ToByteArray();
                }
            }
            return null;
        }

        protected string GetUrlSlug(string postTitle, int postId)
        {
            string result = postId.ToString() + "_";
            result += String.Join("_", postTitle.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            return result;
        }

        protected string GetRGBFromARGB(string color)
        {
            return $"#{color.Substring(2)}";
        }

    }
}