using System.IO;
using System.Linq;

namespace ICCProfReader
{
    public class ICCProfile
    {
        internal static byte[] DataProfile;//array of byte from ICC Profile
        internal TagTable tagTable;//list of all tags in Profile

        private string _numComponents;
        public string NumComponents
        {
            get { return _numComponents; }
        }

        private ColorTypeEnum _clrType;
        public ColorTypeEnum ClrType
        {
            get { return _clrType; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
        }

        public ICCProfile(byte[] dataByte)
        {
            DataProfile = dataByte;
            tagTable = new TagTable(DataProfile);
        }

        internal void GetAll()
        {
            _clrType = GetClrType(DataProfile);
            _numComponents = GetNumComponents(tagTable);
            _description = GetDescription(tagTable);
        }

        private string GetDescription(TagTable tagTable)
        {
            //get entry with profileDescriptionTag signature
            TagTableEntry profDesc = tagTable.tagTbEntry.Where(x => x.TagSignature == TagSignatureEnum.profileDescriptionTag).FirstOrDefault();
            //multiLocalizedUnicode string or not
            TypeSignatureEnum type = (TypeSignatureEnum)Utils.uInt32Number((int)profDesc.OffsetOfBegin);
            TextDescription txtDesc = new TextDescription(type,profDesc);
            return txtDesc.Text.Trim(new char[] { '\0' });//del extra characters
        }

        private ColorTypeEnum GetClrType(byte[] DataProfile)
        {
            //Byte position of colour space of data 16 to 19
            return (ColorTypeEnum)Utils.uInt32Number(16);
        }

        private string GetNumComponents(TagTable tagTable)
        {
            //a three-component matrix-based Input profile shall contain the redMatrixColumnTag
            if (tagTable.tagTbEntry.Any(x=>x.TagSignature==TagSignatureEnum.redMatrixColumnTag))
            {return "3";}
            //a monochrome Input profile shall contain the grayTRCTag
            else if(tagTable.tagTbEntry.Any(x=>x.TagSignature==TagSignatureEnum.grayTRCTag))
            {return "1";}
            else {return "N";}
        }
    }
     

}
