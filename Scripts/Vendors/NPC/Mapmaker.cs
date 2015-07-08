using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class Mapmaker : BaseVendor
    {
        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
        [Constructable]
        public Mapmaker()
            : base("o desenhista de mapas")
        {
            this.SetSkill(SkillName.Cartography, 90.0, 100.0);
            this.Title = this.Female ? "a desenhista de mapas" : "o desenhista de mapas";
        }

        public Mapmaker(Serial serial)
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
            this.m_SBInfos.Add(new SBMapmaker());
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