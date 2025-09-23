using UnityEngine;


    public static class CharacterDirection
    {
        public enum Directions
        {
            N, S, E, W, NE, NW, SE, SW
        }
        
       
        
        public static Directions GetDirection(Vector2 dir,Directions lastDirection)
        {
            if (dir.x > 0 && dir.y == 0) return Directions.E;
            if (dir.x < 0 && dir.y == 0) return Directions.W;
            if (dir.y > 0 && dir.x == 0) return Directions.N;
            if (dir.y < 0 && dir.x == 0) return Directions.S;

            if (dir.x > 0 && dir.y > 0) return Directions.NE;
            if (dir.x < 0 && dir.y > 0) return Directions.NW;
            if (dir.x > 0 && dir.y < 0) return Directions.SE;
            if (dir.x < 0 && dir.y < 0) return Directions.SW;

            return lastDirection;
        }

    }
