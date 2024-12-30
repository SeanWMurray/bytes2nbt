# bytes2nbt - C#
C# classes to convert from bytes to Minecraft NBT in an object-form

I made this for a personal project to manipulate Minecraft chunks, so I have not tested this for items, but it should (hopefully) work for them as well. It also contains very little exception catches for malformed NBT, as the input is coming from Minecraft, and I really only needed it for a one-time use.

How to use:
- NBTParser: Declare new NBTParser object, passing it a byte array of your (uncompressed) NBT data.
- NBTTag: Declare new NBTTag abstract, equal to the parser object, calling ParseNbt

Example:
```
byte[] rawBytes = (the raw bytes to be parsed)
NBTParser nbtData = new NBTParser(rawBytes);
NBTTag tagObject = nbtData.ParseNbt();
```

Additional notes:
- I just straight-up copied these files from my VS so you'll probably have to change the namespace lol
- This obviously isn't optimized, I made it in a day
- I've also included a static NBTPrinter class for debugging purposes
- Use the code however you want 
