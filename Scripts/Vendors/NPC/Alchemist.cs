using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class Alchemist : BaseVendor
    {
        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
        [Constructable]
        public Alchemist()
            : base("o alquimista") //this will be overwrite with the beyond one, so just set the normal one (ex. the Alchemist)
            
        {
            this.SetSkill(SkillName.Alchemy, 85.0, 100.0);
            this.SetSkill(SkillName.TasteID, 65.0, 88.0);
            this.Title = this.Female ? "a alquimista" : "o alquimista"; 
            //now, if your language have prefixes for each male and female, 
            //set it here, doing it by first female and then male after (ex. this.Title = this.Female ? "female" : "male")
        }

        public Alchemist(Serial serial)
            : base(serial)
        {
        }

        public override NpcGuild NpcGuild
        {
            get
            {
                return NpcGuild.MagesGuild;
            }
        }
        public override VendorShoeType ShoeType
        {
            get
            {
                return Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals;
            }
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
            this.m_SBInfos.Add(new SBAlchemist());
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            this.AddItem(new Server.Items.Robe(Utility.RandomPinkHue()));
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
