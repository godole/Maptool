using System;
using System.Collections.Generic;

public class MapData
{
    public IList<NormalObjectlData> NormalObjectList;
    public IList<NormalObjectlData> GroundObjectList;
    public IList<NiddleObjectData> NiddleObjectList;
    public IList<RopeObjectData> RopeObjectList;
    public IList<SpringObjectData> SpringObjectList;
    public GroundObjectData GroundData;

    public int MapLength;
    public string MapName;
    public int BPM;

    public MapData()
    {
        NormalObjectList = new List<NormalObjectlData>();
        GroundObjectList = new List<NormalObjectlData>();
        NiddleObjectList = new List<NiddleObjectData>();
        RopeObjectList = new List<RopeObjectData>();
        SpringObjectList = new List<SpringObjectData>();
        GroundData = new GroundObjectData();
    }
}

public class NormalObjectlData
{
    public string ObjectType { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}

public class NiddleObjectData
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Count { get; set; }
    public bool IsFlip { get; set; }
}

public class RopeObjectData
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int HitPosX { get; set; }
    public int HitPosY { get; set; }
    public double Angle { get; set; }
    public int Length { get; set; }
}

public class SpringObjectData
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int SizeCount { get; set; }
    public int Count { get; set; }
    public bool IsUpStart { get; set; }
}

public class GroundObjectData
{
    public IList<int> HoleList { get; set; }
    public int GroundY;

    public GroundObjectData()
    {
        HoleList = new List<int>();
    }
}