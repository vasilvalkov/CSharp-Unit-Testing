using System.Collections.Generic;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.Fakes
{
    internal class TeleportStationFake : TeleportStation
    {
        public TeleportStationFake(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location) : base(owner, galacticMap, location)
        {
        }

        internal IBusinessOwner OwnerExposed
        {
            get
            {
                return this.owner;
            }
        }

        internal IEnumerable<IPath> GalacticMapExposed
        {
            get
            {
                return this.galacticMap;
            }
        }

        internal ILocation LocationExposed
        {
            get
            {
                return this.location;
            }
        }

        internal IResources ResoursesExposed
        {
            get
            {
                return this.resources;
            }
        }
    }
}
