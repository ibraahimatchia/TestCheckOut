using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StationeryWebAPI.Models;

namespace StationeryWebAPI.Services
{
    public class StationeryRepository
    {
        private const string CacheKey = "StationeryStore";

        public StationeryRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    //creating an object of stationery
                    var stats = new Stationery[]
                    {
                        new Stationery
                        {
                            Name = "Pen", Color = "Red", Quantity = 5
                        },
                    };
                    ctx.Cache[CacheKey] = stats;
                }
            }
        }


        public Stationery[] GetAllStationery()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Stationery[])ctx.Cache[CacheKey];
            }

            return new Stationery[]
            {
                new Stationery
                {
                    Name = "PlaceHolder", Color = "None", Quantity = 0
                }
            };
        }

        public bool AddStationery(Stationery stationery)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {

                    var currentData = ((Stationery[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(stationery);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }


        public bool UpdateStationery(Stationery stationery)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Stationery[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(stationery);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }

    }
}