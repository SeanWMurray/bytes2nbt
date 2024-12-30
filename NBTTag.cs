using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCWorldViewer.NBT
{
    public abstract class NBTTag
    {
        public abstract byte GetTagType();
    }

    public class NBTByte : NBTTag
    {
        public byte Value { get; set; }

        public NBTByte(byte value)
        {
            Value = value;
        }

        public override byte GetTagType()
        {
            return 0x01; // Tag Byte
        }
    }

    public class NBTShort : NBTTag
    {
        public short Value { get; set; }

        public NBTShort(short value)
        {
            Value = value;
        }

        public override byte GetTagType()
        {
            return 0x02; // Tag Short
        }
    }

    public class NBTInt : NBTTag
    {
        public int Value { get; set; }

        public NBTInt(int value)
        {
            Value = value;
        }

        public override byte GetTagType()
        {
            return 0x03; // Tag Int
        }
    }

    public class NBTLong : NBTTag
    {
        public long Value { get; set; }

        public NBTLong(long value)
        {
            Value = value;
        }

        public override byte GetTagType()
        {
            return 0x04; // Tag Long
        }
    }

    public class NBTFloat : NBTTag
    {
        public float Value { get; set; }

        public NBTFloat(float value)
        {
            Value = value;
        }

        public override byte GetTagType()
        {
            return 0x05; // Tag Float
        }
    }

    public class NBTDouble : NBTTag
    {
        public double Value { get; set; }

        public NBTDouble(double value)
        {
            Value = value;
        }

        public override byte GetTagType()
        {
            return 0x06; // Tag Double
        }
    }

    public class NBTByteArray : NBTTag
    {
        public byte[] Value { get; set; }

        public NBTByteArray(byte[] value)
        {
            Value = value;
        }

        public override byte GetTagType()
        {
            return 0x07; // Tag Byte Array
        }
    }

    public class NBTString : NBTTag
    {
        public string Value { get; set; }

        public NBTString(string value)
        {
            Value = value;
        }

        public override byte GetTagType()
        {
            return 0x08; // Tag String
        }
    }

    public class NBTList : NBTTag
    {
        public List<NBTTag> Items { get; set; }

        public NBTList()
        {
            Items = new List<NBTTag>();
        }

        public void AddItem(NBTTag item)
        {
            Items.Add(item);
        }

        public override byte GetTagType()
        {
            return 0x09; // Tag List
        }
    }

    public class NBTCompound : NBTTag
    {
        public Dictionary<string, NBTTag> Tags { get; set; }

        public NBTCompound()
        {
            Tags = new Dictionary<string, NBTTag>();
        }

        public void AddTag(string name, NBTTag tag)
        {
            Tags[name] = tag;
        }

        public override byte GetTagType()
        {
            return 0x0A;
        }
    }

    public class NBTIntArray : NBTTag
    {
        public int[] Value { get; set; }

        public NBTIntArray(int[] value)
        {
            Value = value;
        }

        public override byte GetTagType()
        {
            return 0x0B;
        }
    }

    public class NBTLongArray : NBTTag
    {
        public long[] Value { get; set; }

        public NBTLongArray(long[] value)
        {
            Value = value;
        }

        public override byte GetTagType()
        {
            return 0x0C; 
        }
    }

    public class NBTEnd : NBTTag
    {
        public override byte GetTagType()
        {
            return 0x00;
        }
    }



}
