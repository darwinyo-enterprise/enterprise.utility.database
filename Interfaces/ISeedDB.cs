using Enterprise.AuthorizationServer.DataLayers;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Utility.Database.Interfaces
{
    public interface ISeedDB
    {
        void SeedAllValues();
    }
}
