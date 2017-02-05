using System;

namespace SchoolSystem.Providers
{
    public class IdProvider : IIdProvider
    {
        private readonly uint lastId;
        private uint id;

        public IdProvider(uint startId, uint maxId)
        {
            this.id = startId;
            this.lastId = maxId;
        }

        public uint GenerateID()
        {
            if (this.id > lastId)
            {
                throw new InvalidOperationException("No more ids can be generated for this instance!");
            }

            return this.id++;
        }
    }
}