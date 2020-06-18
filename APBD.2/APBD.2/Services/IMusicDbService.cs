using APBD._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD._2.Services
{
    public interface IMusicDbService
    {
        Artist GetArtist(int id);

        void UpgradeDate(ArtistRequest request);
    }
}
