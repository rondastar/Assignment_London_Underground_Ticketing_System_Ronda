using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_London_Underground_Ticketing_System
{
    public class RiderSearch
    {
        public static RiderList<Rider> ReturnRidersAtStation(int station, RiderList<Rider> AllRiders)
        {
            RiderList<Rider> RidersFromStation = new RiderList<Rider>();
            foreach (var rider in AllRiders)
            {
                if(rider.StationOn == (Station)station)
                {
                    RidersFromStation.Add(rider);
                }
            }
            return RidersFromStation;
        }

        public static RiderList<Rider> ReturnAllActiveRiders(RiderList<Rider> AllRiders)
        {
            RiderList<Rider> ActiveRiders = new RiderList<Rider>();
            foreach (var rider in AllRiders)
            {
                if (rider.StationOff == Station.Active)
                {
                    ActiveRiders.Add(rider);
                }
            }
            return ActiveRiders;
        }


    } // class
}
