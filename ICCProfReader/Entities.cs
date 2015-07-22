using System.Globalization;
using System.Linq;
using System.Threading;

namespace ICCProfReader
{
    public class TagTableEntry
    {
        internal TagSignatureEnum TagSignature {get;private set;}
        internal uint OffsetOfBegin { get; private set; }//Offset to beginning of tag data element 
        internal uint SizeOfTagData {get;private set;}//Size of tag data element

        internal TagTableEntry(TagSignatureEnum tagSignature, uint offsetOfBegin, uint sizeOfTagData)
        {
            this.TagSignature = tagSignature;
            this.OffsetOfBegin = offsetOfBegin;
            this.SizeOfTagData = sizeOfTagData;
        }
    }

    public class TagTable
    {
        internal TagTableEntry[] tagTbEntry {get;private set;}
        internal TagTable(byte[] tagsArray)
        {
            int index = 128;//The profile header is 128 bytes in length
            int tagCount = (int)Utils.uInt32Number(index);//Byte positions 0 to 3 shall specify the number of tags contained in the tag table
            tagTbEntry = new TagTableEntry[tagCount];

            int len = index + 4 + (12 * tagCount);
            int j = 0;
            for (int i = index + 4; i < len; i += 12)
            {
                TagSignatureEnum tagSignature = (TagSignatureEnum)Utils.uInt32Number(i);//Tag signature (byte position 4 to 7)
                uint OffsetOfBegin = Utils.uInt32Number(i + 4);//Byte positions 8 to 11 (and repeating) shall specify the address of the beginning of the tag data element
                uint SizeOfTagData = Utils.uInt32Number(i + 8);
                tagTbEntry[j] = new TagTableEntry(tagSignature, OffsetOfBegin, SizeOfTagData);
                j++;
            }
        }
    }

    public class TextDescription
    {
        public string Text { get; private set; }
        public LocaleString[] lsText { get; private set; }

        public TextDescription(TypeSignatureEnum type, TagTableEntry profDesc)
        {
            if (type!=TypeSignatureEnum.multiLocalizedUnicode)
            {
                Text = Utils.ASCIIString((int)profDesc.OffsetOfBegin+12, (int)profDesc.SizeOfTagData - 20);
            }
            else
            {
                string curCulture = Thread.CurrentThread.CurrentCulture.Name;
                int index = (int)profDesc.OffsetOfBegin+8;//first 8 byte is type signature or reserved
                int RecordCount = (int)Utils.uInt32Number(index);//Number of records
                int RecordSize = (int)Utils.uInt32Number(index + 4);//the length in bytes of every record. The value is 12
                
                string[] cltInfo = new string[RecordCount];// information about what language and region the string is for
                int[] strLen = new int[RecordCount];
                int[] strOffset = new int[RecordCount];
                int end = index + 8 + RecordCount * RecordSize; 
                int j = 0;
                for (int i = index + 8; i < end; i += RecordSize)
                {
                    cltInfo[j] = Utils.ASCIIString(i, 2)+"-"+Utils.ASCIIString(i + 2, 2);
                    strLen[j] = (int)Utils.uInt32Number(i + 4);
                    strOffset[j] = (int)Utils.uInt32Number(i + 8);
                    j++;
                }
                lsText = new LocaleString[RecordCount];
                for (int i = 0; i < RecordCount; i++)
                { lsText[i] = new LocaleString(cltInfo[i], index + strOffset[i] - 8, strLen[i]); }
                 
                LocaleString ls = lsText.Where(x=>x.Locale.Name==curCulture).FirstOrDefault();
                if (ls!=null)
                {
                    Text = ls.Text;
                }
                else
                {
                    Text = lsText[0].Text;
                }
            }
        }

        public class LocaleString
        {
            public CultureInfo Locale { get; private set; }
            public string Text { get; private set; }
            internal LocaleString(string cltInfo, int idx, int length)
            {
                Locale = new CultureInfo(cltInfo);
                Text = Utils.UnicodeString(idx, length);
            }
        }
    }
}
