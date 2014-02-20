﻿//namespace NegroniGame.Monsters
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using Microsoft.Xna.Framework;
//    using Microsoft.Xna.Framework.Graphics;

//    public abstract class Monster : Interfaces.IMonster
//    {
//        private const float TIME_TO_CHANGE_DIRECTION = 3; // sec 5
//        private const int MOVE_MAX_LENGTH = 80;
//        private const float ANIM_DELAY = 200f;
//        private const int MOB_SPEED = 1;
//        private const int AGGRO_RANGE = 50;

//        private int currentFrame = 0;
//        private readonly int hpPointsInitial;
//        private readonly Random randomGenerator = new Random();
//        private readonly List<Texture2D> monsterTextures;
//        private Texture2D monsterAnim;
//        private Rectangle monsterPosition;
//        private Rectangle animSourcePosition;
//        private int positionsToMove;
//        private float elapsedTimeChangeAnim;
//        private float elapsedTimeChangePos;
//        private bool isInCombatState = false;
//        private string changeDirection = "";

//        public Monster(int numberOfMob, Rectangle initialMonsterPos, string name, List<Texture2D> mobTextures, int initialHpPoints)
//        {
//            this.ID = numberOfMob;
//            this.Name = name;
//            this.monsterPosition = initialMonsterPos;
//            this.monsterTextures = mobTextures;
//            this.monsterAnim = this.monsterTextures[0];
//            this.hpPointsInitial = initialHpPoints;
//            this.HpPointsCurrent = hpPointsInitial;
//            this.DirectionForMovement = -1;
//        }

//        public int ID { get; private set; }
//        public string Name { get; private set; }
//        public int DirectionForMovement { get; private set; }
//        public Rectangle DestinationPosition { get; private set; }
//        public int HpPointsCurrent { get; set; }

//        public void Draw(GameTime gameTime)
//        {
//            new SystemFunctions.Sprite(this.monsterAnim, this.DestinationPosition, this.animSourcePosition).DrawBoxAnim();
//        }

//        public void Update(GameTime gameTime)
//        {
//            if (this.isInCombatState == false &&
//                    (this.HpPointsCurrent < this.hpPointsInitial
//                    || Player.Instance.DestinationPosition.Intersects(new Rectangle(this.DestinationPosition.X - AGGRO_RANGE, this.DestinationPosition.Y - AGGRO_RANGE, 32 + (AGGRO_RANGE * 2), 32 + (AGGRO_RANGE * 2)))))
//            {
//                this.isInCombatState = true;
//            }

//            if (this.isInCombatState == false)
//            {
//                MoveNormal(gameTime);
//            }
//            else
//            {
//                MoveCombat(gameTime);
//            }
//        }

//        private void MoveCombat(GameTime gameTime)
//        {
//            string direction = Math.Abs(Player.Instance.DestinationPosition.X - this.DestinationPosition.X)
//                                        > Math.Abs(Player.Instance.DestinationPosition.Y - this.DestinationPosition.Y)
//                                        ? "horizontal" : "vertical";

//            if (this.changeDirection == "up" || this.changeDirection == "down")
//            {
//                direction = "vertical";
//            }
//            else if (this.changeDirection != "")
//            {
//                direction = "horizontal";
//            }

//            //if (this.changeDirection != "")
//            //{
//            //    direction = this.changeDirection;
//            //}

//            if (direction == "horizontal")
//            {
//                if (this.monsterPosition.X < Player.Instance.CenterOfPlayer.X || this.changeDirection == "right")
//                {
//                    Rectangle newPosition = new Rectangle(this.monsterPosition.X + MOB_SPEED, this.monsterPosition.Y, 32, 32);

//                    if (!IntersectsWithObstacles(newPosition))
//                    {
//                        this.monsterPosition.X += MOB_SPEED;
//                        this.monsterAnim = this.monsterTextures[2]; // moves right
//                        this.DestinationPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y, 32, 32);
//                        //this.changeDirection = "";
//                    }
//                    else if (IntersectsWithObstaclesNoPlayer(newPosition))
//                    {
//                        this.changeDirection = "vertical";
//                    }
//                }
//                else if (this.monsterPosition.X > Player.Instance.CenterOfPlayer.X || this.changeDirection == "left")
//                {
//                    Rectangle newPosition = new Rectangle(this.monsterPosition.X - MOB_SPEED, this.monsterPosition.Y, 32, 32);

//                    if (!IntersectsWithObstacles(newPosition))
//                    {
//                        this.monsterPosition.X -= MOB_SPEED;
//                        this.monsterAnim = this.monsterTextures[1]; // moves left
//                        this.DestinationPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y, 32, 32);
//                        //this.changeDirection = "";
//                    }
//                    else if (IntersectsWithObstaclesNoPlayer(newPosition))
//                    {
//                        this.changeDirection = "vertical";
//                    }
//                }
//            }

//            else if (direction == "vertical")
//            {
//                if (this.monsterPosition.Y < Player.Instance.CenterOfPlayer.Y || this.changeDirection == "down")
//                {
//                    Rectangle newPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y + MOB_SPEED, 32, 32);

//                    if (!IntersectsWithObstacles(newPosition))
//                    {
//                        this.monsterPosition.Y += MOB_SPEED;
//                        this.monsterAnim = this.monsterTextures[0]; // moves down
//                        this.DestinationPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y, 32, 32);
//                        //this.changeDirection = "";
//                    }
//                    else if (IntersectsWithObstaclesNoPlayer(newPosition))
//                    {
//                        this.changeDirection = "horizontal";
//                    }
//                }
//                else if (this.monsterPosition.Y > Player.Instance.CenterOfPlayer.Y || this.changeDirection == "up")
//                {
//                    Rectangle newPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y - MOB_SPEED, 32, 32);

//                    if (!IntersectsWithObstacles(newPosition))
//                    {
//                        this.monsterPosition.Y -= MOB_SPEED;
//                        this.monsterAnim = this.monsterTextures[3]; // moves up
//                        this.DestinationPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y, 32, 32);
//                        //this.changeDirection = "";
//                    }
//                    else if (IntersectsWithObstaclesNoPlayer(newPosition))
//                    {
//                        this.changeDirection = "horizontal";
//                    }
//                }
//            }

//            this.animSourcePosition = Animate(gameTime);


//            // Check if the obstacle is already gone and changes to normal direction
//            if (this.changeDirection == "up" || this.changeDirection == "down")
//            {
//                Rectangle newPosition = new Rectangle(this.monsterPosition.X + MOB_SPEED, this.monsterPosition.Y, 32, 32);

//                if (!IntersectsWithObstaclesNoPlayer(newPosition))
//                {
//                    this.changeDirection = "right";
//                }

//                newPosition = new Rectangle(this.monsterPosition.X - MOB_SPEED, this.monsterPosition.Y, 32, 32);

//                if (!IntersectsWithObstaclesNoPlayer(newPosition))
//                {
//                    this.changeDirection = "left";
//                }
//            }
//            else if (this.changeDirection == "left" || this.changeDirection == "right")
//            {
//                Rectangle newPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y + MOB_SPEED, 32, 32);

//                if (!IntersectsWithObstaclesNoPlayer(newPosition))
//                {
//                    this.changeDirection = "down";
//                }

//                newPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y - MOB_SPEED, 32, 32);

//                if (!IntersectsWithObstaclesNoPlayer(newPosition))
//                {
//                    this.changeDirection = "up";
//                }
//            }
//        }


//        private void MoveNormal(GameTime gameTime)
//        {
//            this.elapsedTimeChangePos += (float)gameTime.ElapsedGameTime.TotalSeconds;

//            if (this.elapsedTimeChangePos >= TIME_TO_CHANGE_DIRECTION)
//            {
//                this.DirectionForMovement = this.randomGenerator.Next(1, 5);
//                this.elapsedTimeChangePos = 0;
//                this.positionsToMove = int.MinValue;
//            }


//            if (this.DirectionForMovement == (int)SystemFunctions.DirectionsEnum.North) // up
//            {
//                if (this.positionsToMove == int.MinValue)
//                {
//                    int maxPosition = (this.monsterPosition.Y > MOVE_MAX_LENGTH) ? MOVE_MAX_LENGTH : this.monsterPosition.Y;
//                    maxPosition = (maxPosition <= 0) ? 0 : maxPosition;

//                    this.positionsToMove = this.randomGenerator.Next(0, maxPosition);
//                }
//                else if (this.positionsToMove > 0)
//                {
//                    Rectangle newPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y - MOB_SPEED, 32, 32);

//                    if (IntersectsWithObstacles(newPosition))
//                    {
//                        this.positionsToMove = int.MinValue;
//                    }
//                    else
//                    {
//                        this.monsterPosition.Y -= MOB_SPEED;
//                        this.monsterAnim = this.monsterTextures[3];
//                        this.positionsToMove -= MOB_SPEED;
//                    }
//                }
//            }

//            else if (this.DirectionForMovement == (int)SystemFunctions.DirectionsEnum.South) // down
//            {
//                if (this.positionsToMove == int.MinValue)
//                {
//                    int maxPosition = ((Screens.GameScreen.ScreenHeight - 170 - this.monsterPosition.Y) > MOVE_MAX_LENGTH) ? MOVE_MAX_LENGTH : (Screens.GameScreen.ScreenHeight - 170 - this.monsterPosition.Y);
//                    maxPosition = (maxPosition < 0) ? 0 : maxPosition;

//                    this.positionsToMove = this.randomGenerator.Next(0, maxPosition);
//                }

//                else if (this.positionsToMove > 0)
//                {
//                    Rectangle newPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y + MOB_SPEED, 32, 32);

//                    if (IntersectsWithObstacles(newPosition))
//                    {
//                        this.positionsToMove = int.MinValue;
//                    }
//                    else
//                    {
//                        this.monsterPosition.Y += MOB_SPEED;
//                        this.monsterAnim = this.monsterTextures[0];
//                        this.positionsToMove -= MOB_SPEED;
//                    }
//                }
//            }

//            else if (this.DirectionForMovement == (int)SystemFunctions.DirectionsEnum.West) // left
//            {
//                if (this.positionsToMove == int.MinValue)
//                {
//                    int maxPosition = (this.monsterPosition.X > MOVE_MAX_LENGTH) ? MOVE_MAX_LENGTH : this.monsterPosition.X;
//                    maxPosition = (maxPosition < 0) ? 0 : maxPosition;

//                    this.positionsToMove = this.randomGenerator.Next(0, maxPosition);
//                }

//                else if (this.positionsToMove > 0)
//                {
//                    Rectangle newPosition = new Rectangle(this.monsterPosition.X - MOB_SPEED, this.monsterPosition.Y, 32, 32);

//                    if (IntersectsWithObstacles(newPosition))
//                    {
//                        this.positionsToMove = int.MinValue;
//                    }
//                    else
//                    {
//                        this.monsterPosition.X -= MOB_SPEED;
//                        this.monsterAnim = this.monsterTextures[1];
//                        this.positionsToMove -= MOB_SPEED;
//                    }
//                }
//            }

//            else if (this.DirectionForMovement == (int)SystemFunctions.DirectionsEnum.East) // right
//            {
//                if (this.positionsToMove == int.MinValue)
//                {
//                    int maxPosition = ((Screens.GameScreen.ScreenWidth - 30 - this.monsterPosition.X) > MOVE_MAX_LENGTH) ? MOVE_MAX_LENGTH : (Screens.GameScreen.ScreenWidth - 30 - this.monsterPosition.X);
//                    maxPosition = (maxPosition < 0) ? 0 : maxPosition;

//                    this.positionsToMove = this.randomGenerator.Next(0, maxPosition);
//                }

//                else if (this.positionsToMove > 0)
//                {
//                    Rectangle newPosition = new Rectangle(this.monsterPosition.X + MOB_SPEED, this.monsterPosition.Y, 32, 32);

//                    if (IntersectsWithObstacles(newPosition))
//                    {
//                        this.positionsToMove = int.MinValue;
//                    }
//                    else
//                    {
//                        this.monsterPosition.X += MOB_SPEED;
//                        this.monsterAnim = this.monsterTextures[2];
//                        this.positionsToMove -= MOB_SPEED;
//                    }
//                }
//            }

//            this.animSourcePosition = Animate(gameTime);
//            this.DestinationPosition = new Rectangle(this.monsterPosition.X, this.monsterPosition.Y, 32, 32);
//        }

//        private bool IntersectsWithObstacles(Rectangle newPosition)
//        {
//            bool intersectsWithObstacles = false;
//            bool intersectsWithAnotherMob = false;
            
//            // checks if the new position intersects with another mob
//            foreach (Monster monster in Monsters.MonstersHandler.Instance.SpawnedMobs)
//            {
//                if (monster.ID != this.ID && monster.DestinationPosition.Intersects(newPosition))
//                {
//                    intersectsWithAnotherMob = true;
//                    break;
//                }
//            }

//            // checks if the new position is not well or market
//            if (Well.Instance.WellPosition.Intersects(newPosition)
//            || Market.Instance.MarketPosition.Intersects(newPosition)
//            || Player.Instance.DestinationPosition.Intersects(newPosition)
//            || intersectsWithAnotherMob == true)
//            {
//                intersectsWithObstacles = true;
//            }

//            return intersectsWithObstacles;
//        }
//        private bool IntersectsWithObstaclesNoPlayer(Rectangle newPosition)
//        {
//            bool intersectsWithObstacles = false;
//            bool intersectsWithAnotherMob = false;

//            // checks if the new position intersects with another mob
//            foreach (Monster monster in Monsters.MonstersHandler.Instance.SpawnedMobs)
//            {
//                if (monster.ID != this.ID && monster.DestinationPosition.Intersects(newPosition))
//                {
//                    intersectsWithAnotherMob = true;
//                    break;
//                }
//            }

//            // checks if the new position is not well or market
//            if (Well.Instance.WellPosition.Intersects(newPosition)
//            || Market.Instance.MarketPosition.Intersects(newPosition)
//            || intersectsWithAnotherMob == true)
//            {
//                intersectsWithObstacles = true;
//            }

//            return intersectsWithObstacles;
//        }

//        private Rectangle Animate(GameTime gameTime)
//        {
//            this.elapsedTimeChangeAnim += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

//            if (this.elapsedTimeChangeAnim >= ANIM_DELAY)
//            {
//                if (this.currentFrame >= 2)
//                {
//                    this.currentFrame = 0;
//                }
//                else
//                {
//                    this.currentFrame++;
//                }
//                this.elapsedTimeChangeAnim = 0;
//            }

//            // if on frame 0 - top up position 0
//            return new Rectangle(32 * currentFrame, 0, 32, 32);
//        }
//    }
//}