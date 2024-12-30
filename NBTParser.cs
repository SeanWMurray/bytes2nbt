using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCWorldViewer.NBT
{
    internal class NBTParser
    {
        byte[] data;
        public NBTParser(byte[] bytes)
        {
            this.data = bytes;
        }

        public NBTTag ParseNbt()
        {
            int position = 0;

            (string Name, NBTTag Tag) ReadNamedTag()
            {
                byte tagType = data[position++];

                if (tagType == 0) // END
                {
                    return ("", new NBTEnd());
                }

                int nameLength = (data[position] << 8) | data[position + 1];
                position += 2;
                string name = Encoding.UTF8.GetString(data, position, nameLength);
                position += nameLength;

                NBTTag tag = tagType switch
                {
                    0x01 => new NBTByte(data[position++]), // Byte
                    0x02 => new NBTShort((short)((data[position++] << 8) | data[position++])), // Short
                    0x03 => new NBTInt((data[position++] << 24) | (data[position++] << 16) |
                                       (data[position++] << 8) | data[position++]), // Int
                    0x04 => ReadLong(), // Long
                    0x05 => ReadFloat(), // Float
                    0x06 => ReadDouble(), // Double
                    0x07 => new NBTByteArray(ReadByteArray()), // Byte Array
                    0x08 => new NBTString(ReadString()), // String
                    0x09 => ReadList(), // List
                    0x0A => ReadCompound(), // Compound
                    0x0B => new NBTIntArray(ReadIntArray()), // Int Array
                    0x0C => new NBTLongArray(ReadLongArray()), // Long Array
                    _ => throw new ArgumentException($"Unknown tag type: {tagType}")
                };

                return (name, tag);
            }

            NBTTag ReadTagWithoutName(byte tagType) // This is so dumb, combine with the original switch statement, just change the return lol
            {
                return tagType switch
                {
                    0x01 => new NBTByte(data[position++]), // Byte
                    0x02 => new NBTShort((short)((data[position++] << 8) | data[position++])), // Short
                    0x03 => new NBTInt((data[position++] << 24) | (data[position++] << 16) |
                                       (data[position++] << 8) | data[position++]), // Int
                    0x04 => ReadLong(), // Long
                    0x05 => ReadFloat(), // Float
                    0x06 => ReadDouble(), // Double
                    0x07 => new NBTByteArray(ReadByteArray()), // Byte Array
                    0x08 => new NBTString(ReadString()), // String
                    0x09 => ReadList(), // List
                    0x0A => ReadCompound(), // Compound
                    0x0B => new NBTIntArray(ReadIntArray()), // Int Array
                    0x0C => new NBTLongArray(ReadLongArray()), // Long Array
                    _ => throw new ArgumentException($"Unknown tag type: {tagType}")
                };
            }

            NBTLong ReadLong()
            {
                var value = BitConverter.ToInt64(data.AsSpan(position, 8).ToArray().Reverse().ToArray(), 0);
                position += 8;
                return new NBTLong(value);
            }

            NBTFloat ReadFloat()
            {
                var value = BitConverter.ToSingle(data.AsSpan(position, 4).ToArray().Reverse().ToArray(), 0);
                position += 4;
                return new NBTFloat(value);
            }

            NBTDouble ReadDouble()
            {
                var value = BitConverter.ToDouble(data.AsSpan(position, 8).ToArray().Reverse().ToArray(), 0);
                position += 8;
                return new NBTDouble(value);
            }

            byte[] ReadByteArray()
            {
                int length = (data[position++] << 24) | (data[position++] << 16) |
                             (data[position++] << 8) | data[position++];
                byte[] array = new byte[length];
                Array.Copy(data, position, array, 0, length);
                position += length;
                return array;
            }

            string ReadString()
            {
                int length = (data[position++] << 8) | data[position++];
                string value = Encoding.UTF8.GetString(data, position, length);
                position += length;
                return value;
            }

            NBTList ReadList()
            {
                byte listType = data[position++];
                int length = (data[position++] << 24) | (data[position++] << 16) |
                             (data[position++] << 8) | data[position++];
                var list = new NBTList();

                for (int i = 0; i < length; i++)
                {
                    NBTTag item = ReadTagWithoutName(listType);
                    list.AddItem(item);
                }

                return list;
            }

            NBTCompound ReadCompound()
            {
                var compound = new NBTCompound();
                while (true)
                {
                    var (name, tag) = ReadNamedTag();
                    if (tag is NBTEnd)
                    {
                        break;
                    }
                    compound.AddTag(name, tag);
                }

                return compound;
            }

            int[] ReadIntArray()
            {
                int length = (data[position++] << 24) | (data[position++] << 16) |
                             (data[position++] << 8) | data[position++];
                int[] array = new int[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = (data[position++] << 24) | (data[position++] << 16) |
                               (data[position++] << 8) | data[position++];
                }
                return array;
            }

            long[] ReadLongArray()
            {
                int length = (data[position++] << 24) | (data[position++] << 16) |
                             (data[position++] << 8) | data[position++];
                long[] array = new long[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = BitConverter.ToInt64(data.AsSpan(position, 8).ToArray().Reverse().ToArray(), 0);
                    position += 8;
                }
                return array;
            }

            var (rootName, rootTag) = ReadNamedTag();
            return rootTag;
        }
    }
}
