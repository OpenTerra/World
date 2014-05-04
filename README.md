OpenTerra.World
===============

Handles the saving/loading/handling of the world data.

-----------------------------------------------------------------------------------------------

OpenTerra Layer Format: World/Layers/tileId-tileName.otlayer

Maximum Layer (World) size: 16,320 x 16,320 Tiles

-----------------------------------------------------------------------------------------------

Structure:

```
(complete maximum length: 68,217,339,393 Bytes - a whopping 63.53 GiB)
ushort tileId
ushort layerDataLength
byte[layerDataLength] layerData (for all Tiles; parsed by Tile)

byte #rows
uint[#rows] bytes offset from start of last one (from start of file for first)
Row[#rows] rows (64 tiles high; bottom to top; not empty; max length: 68,217,272,835 Bytes):
	(max length: 267,518,717 Bytes)
    byte rowIndex
    byte #chunks
    uint[#chunks] bytes offset from start of last one (0 for first)
    Chunk[#chunks] chunks (64 tiles wide; ltr btt; not empty; max length: 267,517,695 Bytes):
		(max length: 1,049,089 Bytes)
        byte chunkIndex
        Tile[64*64] tiles (0 bit for empty; 1 bit for occupied, followed by data):
			(max length: 256.125 Bytes)
            bit occupied
            byte tileDataLength
            byte[tileDataLength] tileData (parsed by Tile)
```

-----------------------------------------------------------------------------------------------

Data ranges:

```
bit: 0 - 1
byte (8 bit): 0 - 255
ushort (2 byte / 16 bit): 0 - 65,535
uint (4 byte / 32 bit): 0 - 4,294,967,295
```