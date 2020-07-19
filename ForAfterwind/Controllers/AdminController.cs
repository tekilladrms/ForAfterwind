using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public IActionResult Video()
        {
            return View(db.VideoAlbums.AsNoTracking());
        }

        [HttpGet]
        public IActionResult Audio()
        {
            return View(db.Releases.AsNoTracking());
        }

        [HttpGet]
        public IActionResult Photo()
        {
            return View(db.PhotoAlbums.AsNoTracking());
        }

        [HttpGet]
        public IActionResult Musician()
        {
            return View(db.Musicians.AsNoTracking());
        }

        [HttpGet]
        public IActionResult Blog()
        {
            return View(db.Posts.AsNoTracking());    
        }

        // CRUD

        //PartialViews

        [HttpGet]
        public PartialViewResult _partialSkills(int? id)
        {
            if (id == null)
            {
                return PartialView();
            }
            return PartialView(db.Skills.Where(x => x.MusicianId == id).ToList());
        }

        [HttpGet]
        public PartialViewResult _socialLinks(int? id)
        {
            if (id == null)
            {
                return PartialView();
            }
            return PartialView(db.SocialLinks.Where(x => x.MusicianId == id).ToList());
        }

        [HttpGet]
        public PartialViewResult _partialSongs(int? id)
        {
            if (id == null)
            {
                return PartialView();
            }
            return PartialView(db.Songs.Where(x => x.ReleaseId == id).ToList());
        }

        [HttpGet]
        public PartialViewResult _partialVideos(int? id)
        {
            if (id == null)
            {
                return PartialView();
            }
            return PartialView(db.Videos.Where(x => x.VideoAlbumId == id).ToList());
        }

        [HttpGet]
        public PartialViewResult _partialPhotos(int? id)
        {
            if (id == null)
            {
                return PartialView();
            }
            return PartialView(db.Photos.Where(x => x.PhotoAlbumId == id).ToList());
        }

        //Edit

        public async Task<PartialViewResult> EditLink(int? id, string name, string path)
        {
            SocialLink link = await db.SocialLinks.FirstOrDefaultAsync(x => x.Id == id);
            link.Name = name;
            link.Path = path;
            db.SocialLinks.Update(link);
            await db.SaveChangesAsync();
            return _socialLinks(link.MusicianId);
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
                string path = $"/Media/Albums/{release.Name}/{uploadedFile.FileName}";
                using (var fileStream = new FileStream(
                    _appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                release.PathToCover = path;
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
        public void CreateSkill(int? id, string name)
        {
            Skill skill = new Skill();
            skill.Name = name;
            skill.MusicianId = id;
            skill.Musician = db.Musicians.FirstOrDefault(x => x.Id == id);

            db.Skills.Add(skill);
            db.SaveChanges();
            
        }

        [HttpPost]
        public void CreateLink(int? id, string name, string url)
        {
            SocialLink link = new SocialLink();
            link.Name = name.ToLower();
            link.MusicianId = id;
            link.Path = url;
            link.Musician = db.Musicians.FirstOrDefault(x => x.Id == id);
            db.SocialLinks.Add(link);
            db.SaveChanges();
        }

        [HttpPost]
        public void AddVideo(int? id, IFormFile uploadedFile)
        {
            VideoAlbum videoAlbum = db.VideoAlbums.FirstOrDefault(x => x.Id == id);
            Video video = new Video();
            string path = $"/Media/Video/{videoAlbum.Name}/{uploadedFile.FileName}";

            using (FileStream fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create, FileAccess.Write))
            {
                uploadedFile.CopyTo(fileStream);
            }
            video.Name = uploadedFile.FileName;
            video.VideoAlbumId = id;
            video.PathToVideo = path;
            video.VideoAlbum = db.VideoAlbums.FirstOrDefault(x => x.Id == id);
            db.Videos.Add(video);
            db.SaveChanges();
            
        }

        [HttpPost]
        public void AddPhotos(int? id, IEnumerable<IFormFile> files)
        {
            PhotoAlbum photoAlbum = db.PhotoAlbums.FirstOrDefault(x => x.Id == id);

            foreach (var file in files)
            {
                string path = $"/Media/Photo albums/{photoAlbum.Name}/{file.FileName}";
                using (FileStream fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
                Photo photo = new Photo();
                photo.PathToPhoto = path;
                photo.PhotoAlbum = photoAlbum;
                photo.PhotoAlbumId = id;
                db.Photos.Add(photo);
            }
            db.SaveChanges();
            
        }

        [HttpPost]
        public void AddSongs(int? id, IEnumerable<IFormFile> uploadedFiles)
        {

            if (uploadedFiles != null)
            {
                Release release = db.Releases.FirstOrDefault(x => x.Id == id);

                foreach(var file in uploadedFiles)
                {
                    string path = $"/Media/Albums/{release.Name}/" + file.FileName;

                    using (var fileStream = new FileStream(
                        _appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
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
                    
                    db.Songs.Add(song);
                }
                db.SaveChanges();

            }

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


        public void DeleteSkill(int? id)
        {
            Skill skill = db.Skills.FirstOrDefault(x => x.Id == id);
            db.Skills.Remove(skill);
            db.SaveChanges();
        }
        
        public void DeleteLink(int? id)
        {
            SocialLink link = db.SocialLinks.FirstOrDefault(x => x.Id == id);
            db.SocialLinks.Remove(link);
            db.SaveChanges();
        }
        
        public void DeleteSong(int? id)
        {
            Song song = db.Songs.FirstOrDefault(x => x.Id == id);
            db.Songs.Remove(song);
            db.SaveChanges();
            DeleteFileFromDirectory(song.PathToSong);
        }
        
        public void DeleteVideo(int? id)
        {
            Video video = db.Videos.FirstOrDefault(x => x.Id == id);
            db.Videos.Remove(video);
            db.SaveChanges();
            DeleteFileFromDirectory(video.PathToVideo);
        }
        
        public void DeletePhoto(int? id)
        {
            Photo photo = db.Photos.FirstOrDefault(x => x.Id == id);
            db.Photos.Remove(photo);
            db.SaveChanges();
            DeleteFileFromDirectory(photo.PathToPhoto);
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

    }
}