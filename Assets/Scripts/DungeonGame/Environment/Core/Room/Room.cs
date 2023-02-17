using System;
using System.Collections.Generic;
using Nico.Interface;
using UnityEngine;

namespace DungeonGame.Core
{
    public enum RoomType
    {
    }

    public class Room
    {
        public RoomType roomType;
        public Vector2Int center;
        public BoundsInt bounds;
        public HashSet<Room> neighbors = new HashSet<Room>();
        public List<Wall> walls = new List<Wall>();
        public List<Floor> floors = new List<Floor>();
        public HashSet<Vector2Int> floorPoints;

        public Room(Vector2Int center, BoundsInt bounds, HashSet<Vector2Int> floorPoints)
        {
            this.center = center;
            this.bounds = bounds;
            this.floorPoints = floorPoints;
        }

        public static float Distance(Room a, Room b)
        {
            return Nico.Algorithm.Distance.Manhattan(a.center, b.center);
        }
        
    }
}