﻿using System;
using Microsoft.Xna.Framework;
using SadRogue.Entities;
using System.Text;
using GoRogue.DiceNotation;

namespace SadRogue.Commands
{
    // Contains all generic actions performed on entities and tiles
    // including combot, movement, and so on.
    public class CommandManager
    {
        // Stores the actor's last move action
        private Point _lastMoveActorPoint;
        private Actor _lastMoveActor;

        public CommandManager()
        {
                

        }

        // Move the actor BY +/= X&Y coordinates
        // return true if the move was successful
        // and false if unable to move there
        public bool MoveActorBy(Actor actor, Point position)
        {
            // Store the actor's last move state
            _lastMoveActor = actor;
            _lastMoveActorPoint = position;

            return actor.MoveBy(position);
        }

        // Redo the last actor move
        public bool RedoMoveActorBy()
        {
            // Make sure there is an actor available to redo first
            if (_lastMoveActor != null)
            {
                return _lastMoveActor.MoveBy(_lastMoveActorPoint);
            }
            else
                return false;
               
        }

        // Undo last actor move
        // then clear the undo so it cannot be repeated
        public bool UndoMoveActorBy()
        {
            // Make sure there is an actor available to undo first
            if (_lastMoveActor != null)
            {
                // Reverse the directions of the last move
                _lastMoveActorPoint = new Point(-_lastMoveActorPoint.X, -_lastMoveActorPoint.Y);

                if (_lastMoveActor.MoveBy(_lastMoveActorPoint))
                {
                    _lastMoveActorPoint = new Point(0, 0);
                    return true;
                }
                else
                {
                    _lastMoveActorPoint = new Point(0, 0);
                    return false;
                }
            }
            return false;
        }

        // Executes an attack from an attacking actor
        // on a defending actor, and then describes
        // the outcome of the attack in the Message Log
        public void Attack(Actor attacker, Actor defender)
        {
            // Create two messages that describe the outcome
            // of the attack and defense
            StringBuilder attackMessage = new StringBuilder();
            StringBuilder defenseMessage = new StringBuilder();

            // Count up the amount of attacking damage done
            // and the number of successful blocks
            int hits = ResolveAttack(attacker, defender, attackMessage);
            int blocks = ResolveDefense(defender, hits, attackMessage, defenseMessage);

            // Display the outcome of the attack & defense
            GameLoop.UIManager.MessageLog.Add(attackMessage.ToString());
            if (!String.IsNullOrWhiteSpace(defenseMessage.ToString()))
            {
                GameLoop.UIManager.MessageLog.Add(defenseMessage.ToString());
            }

            int damage = hits - blocks;

            // The defender now takes damage
            ResolveDamage(defender, damage);
        }

        // Calculates the outcome of an attacker's attempt
        // at scoring a hit on a defender, using the attacker's
        // AttackChance and a random d100 roll as the basis.
        // Modifies a StringBuilder message that will be displayed
        // in the MessageLog
        private static int ResolveAttack(Actor attacker, Actor defender, StringBuilder attackMessage)
        {
            // Create a string that expresses the attacker and defender's names
            int hits = 0;
            attackMessage.AppendFormat("{0} attacks {1}, and rolls: ", attacker.Name, defender.Name);

            // The attacker's Attack value determines the number of D100 dice rolled
            for (int dice = 0; dice < attacker.Attack; dice++)
            {
                // Roll a single D100 and add its results to the attack message
                int diceOutcome = Dice.Roll("1d100");
                attackMessage.AppendFormat($"{diceOutcome} ");

                // Resolve the dicing outcome and register a hit, govered by the
                // atttacker's AttackChance value.
                if (diceOutcome >= 100 - attacker.AttackChance)
                    hits++;
            }

            return hits;
        }

        // Calculates the outcome of a defender's attempt
        // at blocking the incoming hits.
        // Modifies a StringBuilder message that will be displayed
        // in the MessageLog, expressing the number of hits blocked.
        private static int ResolveDefense(Actor defender, int hits, StringBuilder attackMessage, StringBuilder defenseMessage)
        {
            int blocks = 0;
            if (hits > 0)
            {
                // Create a string that displays the defender's name and outcomes
                attackMessage.AppendFormat("scoring {0} hits.", hits);
                defenseMessage.AppendFormat("{0} defends and rolls: ", defender.Name);

                // The defender's Defense value determines the number of D100 dice rolled
                for (int dice = 0; dice < defender.Defense; dice++)
                {
                    // Roll a single D100 and add its results to the defense Message
                    int diceOutcome = Dice.Roll("1d100");
                    defenseMessage.AppendFormat($"{diceOutcome} ");

                    // Resolve the dicing outcome and register a block, governed by the
                    // attacker's DefenceChance value.
                    if (diceOutcome >= 100 - defender.DefenseChance)
                        blocks++;
                }
                defenseMessage.AppendFormat("resulting in {0} blocks.", blocks);
            }
            else
            {
                attackMessage.Append("and misses completely!");
            }
            return blocks;
        }

        // Calculates the damage a defender takes after a successful hit
        // and subtracts it from its Health
        // Then displays the outcome in the MessageLog.
        private static void ResolveDamage(Actor defender, int damage)
        {
            if (damage > 0)
            {
                defender.Health = defender.Health - damage;
                GameLoop.UIManager.MessageLog.Add($"{defender.Name} was hit for {damage} damage");
                if (defender.Health <= 0)
                {
                    ResolveDeath(defender);
                }
            }
            else
            {
                GameLoop.UIManager.MessageLog.Add($"{defender.Name} blocked all damage!");
            }
        }

        // Removes an Actor that has died
        // and displays a message showing who died
        private static void ResolveDeath(Actor defender)
        {
<<<<<<< HEAD
            // Dump the dead actor's inventory (if any)
=======
            // dump the dead actor's inventory (if any)
>>>>>>> 6c0f49586563549f07fb130268896d55b1beda14
            // on to the map position where it died
            foreach (Item item in defender.Inventory)
            {
                item.Position = defender.Position;
                GameLoop.EntityManager.Entities.Add(item);
            }

            GameLoop.EntityManager.Entities.Remove(defender);

            if (defender is Player)
            {
                GameLoop.UIManager.MessageLog.Add($" {defender.Name} was killed.");
            }
            else if (defender is Monster)
            {
                GameLoop.UIManager.MessageLog.Add($"{defender.Name} died.");
            }
        }

        // Tries to pick up an Item and add it to the Actor's
        // inventory list
        public void Pickup(Actor actor, Item item)
        {
            // Add the item to the Actor's inventory list
            // and then remove it from the EntityManager
            actor.Inventory.Add(item);
            GameLoop.UIManager.MessageLog.Add($"{actor.Name} picked up {item.Name}");
            item.Destroy();
        }

    }
}
