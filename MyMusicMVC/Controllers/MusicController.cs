﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyMusicMVC.Models;
using MyMusicMVC.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyMusicMVC.Controllers
{
    public class MusicController : Controller
    {
        private readonly IConfiguration _Config;
        private string URLBase
        {
            get
            {
                return _Config.GetSection("BaseURL").GetSection("URL").Value;
            }
        }
        public MusicController(IConfiguration Config)
        {
            _Config = Config;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddMusic()
        {
            var musicViwModel = new MusiViewModel();
            List<Artist> artistList = new List<Artist>();

            using (var httpClient = new HttpClient())
            {
                using (var respense = await httpClient.GetAsync(URLBase + "Artist"))
                {
                    string apiResponse = await respense.Content.ReadAsStringAsync();

                    artistList = JsonConvert.DeserializeObject<List<Artist>>(apiResponse);
                }
            }
            musicViwModel.ArtistList = new SelectList(artistList, "Id", "Name");
            return View(musicViwModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddMusic(MusiViewModel musicModelView)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    var music = new Music() { ArtistId = int.Parse(musicModelView.AristId), Name = musicModelView.Music.Name };
                    var JWToken = HttpContext.Session.GetString("token");
                    if (string.IsNullOrEmpty(JWToken))
                    {
                        ViewBag.MessageError = "You must be authenticate";
                        return View(musicModelView);
                    }
                    
                    string stringData = JsonConvert.SerializeObject(music);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    //le header à ajouter dans la requete
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", JWToken);
                    var response = await client.PostAsync(URLBase + "Music", contentData);
                    var result = response.IsSuccessStatusCode;
                    if (result)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ViewBag.MessageError = response.ReasonPhrase;
                    return View(musicModelView);

                }

            }
            return View(musicModelView);
        }

    }
}
