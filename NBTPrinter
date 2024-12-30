using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCWorldViewer.NBT
{
    public static class NBTPrinter
    {
        public static void PrintNBT(NBTTag tag, string name = "", int indent = 0)
        {
            string indentStr = new string(' ', indent * 2);

            switch (tag)
            {
                case NBTByte byteTag:
                    Console.WriteLine($"{indentStr}TAG_Byte{(name != "" ? $"(\"{name}\")" : "")}: {byteTag.Value}");
                    break;

                case NBTShort shortTag:
                    Console.WriteLine($"{indentStr}TAG_Short{(name != "" ? $"(\"{name}\")" : "")}: {shortTag.Value}");
                    break;

                case NBTInt intTag:
                    Console.WriteLine($"{indentStr}TAG_Int{(name != "" ? $"(\"{name}\")" : "")}: {intTag.Value}");
                    break;

                case NBTLong longTag:
                    Console.WriteLine($"{indentStr}TAG_Long{(name != "" ? $"(\"{name}\")" : "")}: {longTag.Value}");
                    break;

                case NBTFloat floatTag:
                    Console.WriteLine($"{indentStr}TAG_Float{(name != "" ? $"(\"{name}\")" : "")}: {floatTag.Value}");
                    break;

                case NBTDouble doubleTag:
                    Console.WriteLine($"{indentStr}TAG_Double{(name != "" ? $"(\"{name}\")" : "")}: {doubleTag.Value}");
                    break;

                case NBTByteArray byteArrayTag:
                    Console.WriteLine($"{indentStr}TAG_Byte_Array{(name != "" ? $"(\"{name}\")" : "")}: {byteArrayTag.Value.Length} bytes");
                    break;

                case NBTString stringTag:
                    Console.WriteLine($"{indentStr}TAG_String{(name != "" ? $"(\"{name}\")" : "")}: {stringTag.Value}");
                    break;

                case NBTList listTag:
                    Console.WriteLine($"{indentStr}TAG_List{(name != "" ? $"(\"{name}\")" : "")} ({listTag.Items.Count} entries)");
                    foreach (var item in listTag.Items)
                    {
                        PrintNBT(item, "", indent + 1);
                    }
                    break;

                case NBTCompound compoundTag:
                    Console.WriteLine($"{indentStr}TAG_Compound{(name != "" ? $"(\"{name}\")" : "")} ({compoundTag.Tags.Count} entries)");
                    foreach (var (tagName, tagValue) in compoundTag.Tags)
                    {
                        PrintNBT(tagValue, tagName, indent + 1);
                    }
                    break;

                case NBTIntArray intArrayTag:
                    Console.WriteLine($"{indentStr}TAG_Int_Array{(name != "" ? $"(\"{name}\")" : "")}: {intArrayTag.Value.Length} integers");
                    break;

                case NBTLongArray longArrayTag:
                    Console.WriteLine($"{indentStr}TAG_Long_Array{(name != "" ? $"(\"{name}\")" : "")}: {longArrayTag.Value.Length} longs");
                    break;

                case NBTEnd _:
                    Console.WriteLine($"{indentStr}TAG_End");
                    break;
            }
        }
    }
}
