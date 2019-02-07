using System;
using System.Collections.Generic;
using MFoxGame.Services;
using MFoxGame.Models;
using MFoxGame.ViewModels;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace MFoxGame.Controllers
{

    public class ItemsController
    {
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static ItemsController _instance;

        public static ItemsController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ItemsController();
                }
                return _instance;
            }
        }

        // Return the Default Image URI for the Local Image for an Item.
        public static string DefaultImageURI = "Item.png";
        public static string DefaultImageURICharacter = "mellowfoxgamelogo1.PNG";

    }
}
