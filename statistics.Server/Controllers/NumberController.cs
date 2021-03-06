﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using statistics.Server.Services;
using TrackerApi;
using WikiClientLibrary.Client;
using WikiClientLibrary.Sites;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace statistics.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    public class NumberController : Controller
    {
        public int Sum { get; set; }
        private readonly AppState _state;
        private readonly WikiClient _wc;
        private readonly WikiSite _cswiki;
        public NumberController(AppState state, WikiClient wc, WikiSite cswiki)
        {
            _state = state;
            _wc = wc;
            _cswiki = cswiki;

            Sum = _state.FotimeCeskoPhotos;
            _state.OnFotimeCeskoPhotosUpdated += OnFotimeCeskoPhotosUpdated;
        }

        public int FotimeCeskoPhotos()
        {
            _state.UpdateFotimeCeskoPhotos();
            return Sum;
        }

        public void OnFotimeCeskoPhotosUpdated()
        {
            Sum = _state.FotimeCeskoPhotos;
        }
    }
}
