using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class VarietyDealer : BaseVendor
    {
        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
        [Constructable]
        public VarietyDealer()
            : base("o vendedor de especiarias")
             {
                 this.Title = this.Female ? "a vendedora de especiarias" : "o vendedor de especiarias";
        }

        public VarietyDealer(Serial serial)
            : base(serial)
        {
        }

        protected override List<SBInfo> SBInfos
        {
            get
            {
                return this.m_SBInfos;
            }
        }
        public override void InitSBInfo()
        {
            this.m_SBInfos.Add(new SBVarietyDealer());
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}