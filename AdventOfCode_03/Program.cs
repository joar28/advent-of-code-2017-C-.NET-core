using System;

class AdventOfCode_03
{
    static void Main(string[] args)
    {
        Console.WriteLine(Distance(1));
        Console.WriteLine(Distance(12));
        Console.WriteLine(Distance(23));
        Console.WriteLine(Distance(1024));
        Console.WriteLine(Distance(265149));

        Console.WriteLine(DistanceStress(265149));
        
    }
    enum Direction{
        up,
        down,
        left,
        right
    }
    static int Distance(int Location)
    {
        int distance = 0;
        
        var drive = new int[2000][];
        for(int i = 0; i < 2000; i++)
        {
            drive[i] = new int[2000];
        }

        var startCoord = 1000;
        var coordX = startCoord;
        var coordY = startCoord;
        
        Direction? dir = null;
        for(int i = 1; i < Location; i++)
        {
            switch(dir){
                case Direction.up:
                    drive[coordX][coordY] = i;
                    if(drive[coordX-1][coordY] == 0)
                    {
                        dir = Direction.left;
                        coordX--;
                    }
                    else
                    {
                        coordY--;
                    }
                break;
                case Direction.down:
                    drive[coordX][coordY] = i;
                    if(drive[coordX+1][coordY] == 0)
                    {
                        dir = Direction.right;
                        coordX++;
                    }
                    else
                    {
                        coordY++;
                    }
                break;
                case Direction.left:
                    drive[coordX][coordY] = i;
                    if(drive[coordX][coordY+1] == 0)
                    {
                        dir = Direction.down;
                        coordY++;
                    }
                    else
                    {
                        coordX--;
                    }
                break;
                case Direction.right:
                    drive[coordX][coordY] = i;
                    if(drive[coordX][coordY-1] == 0)
                    {
                        dir = Direction.up;
                        coordY--;
                    }
                    else
                    {
                        coordX++;
                    }
                break;
                default:
                    drive[coordX++][coordY] = i;
                    dir = Direction.right;
                break;
            }
        }
        distance = (Math.Abs(startCoord-coordX))+(Math.Abs(startCoord-coordY));
        return distance;
    }

    static int DistanceStress(int Location)
    {
        
        var drive = new int[2000][];
        for(int i = 0; i < 2000; i++)
        {
            drive[i] = new int[2000];
        }

        var startCoord = 1000;
        var coordX = startCoord;
        var coordY = startCoord;
        
        Direction? dir = null;
        for(int i = 1; i < Location; i++)
        {
            switch(dir){
                case Direction.up:
                    drive[coordX][coordY] = drive[coordX+1][coordY+1] + drive[coordX+1][coordY] + drive[coordX+1][coordY-1] + drive[coordX][coordY+1] + drive[coordX][coordY-1] + drive[coordX-1][coordY+1] + drive[coordX-1][coordY] + drive[coordX-1][coordY-1];
                    if(drive[coordX][coordY] > Location){
                        return drive[coordX][coordY];
                    }
                    if(drive[coordX-1][coordY] == 0)
                    {
                        dir = Direction.left;
                        coordX--;
                    }
                    else
                    {
                        coordY--;
                    }
                break;
                case Direction.down:
                    drive[coordX][coordY] = drive[coordX+1][coordY+1] + drive[coordX+1][coordY] + drive[coordX+1][coordY-1] + drive[coordX][coordY+1] + drive[coordX][coordY-1] + drive[coordX-1][coordY+1] + drive[coordX-1][coordY] + drive[coordX-1][coordY-1];
                    if(drive[coordX][coordY] > Location){
                        return drive[coordX][coordY];
                    }
                    if(drive[coordX+1][coordY] == 0)
                    {
                        dir = Direction.right;
                        coordX++;
                    }
                    else
                    {
                        coordY++;
                    }
                break;
                case Direction.left:
                    drive[coordX][coordY] = drive[coordX+1][coordY+1] + drive[coordX+1][coordY] + drive[coordX+1][coordY-1] + drive[coordX][coordY+1] + drive[coordX][coordY-1] + drive[coordX-1][coordY+1] + drive[coordX-1][coordY] + drive[coordX-1][coordY-1];
                    if(drive[coordX][coordY] > Location){
                        return drive[coordX][coordY];
                    }
                    if(drive[coordX][coordY+1] == 0)
                    {
                        dir = Direction.down;
                        coordY++;
                    }
                    else
                    {
                        coordX--;
                    }
                break;
                case Direction.right:
                    drive[coordX][coordY] = drive[coordX+1][coordY+1] + drive[coordX+1][coordY] + drive[coordX+1][coordY-1] + drive[coordX][coordY+1] + drive[coordX][coordY-1] + drive[coordX-1][coordY+1] + drive[coordX-1][coordY] + drive[coordX-1][coordY-1];
                    if(drive[coordX][coordY] > Location){
                        return drive[coordX][coordY];
                    }
                    if(drive[coordX][coordY-1] == 0)
                    {
                        dir = Direction.up;
                        coordY--;
                    }
                    else
                    {
                        coordX++;
                    }
                break;
                default:
                    drive[coordX++][coordY] = i;
                    dir = Direction.right;
                break;
            }
        }
        return 0;
        
    }


}
