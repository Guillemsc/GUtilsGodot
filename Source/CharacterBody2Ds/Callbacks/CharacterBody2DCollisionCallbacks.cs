using System;
using System.Collections.Generic;
using Godot;
using GUtils.Extensions;

namespace GUtilsGodot.CharacterBody2Ds.Callbacks;

public partial class CharacterBody2DCollisionCallbacks : Node2D
{
    [Export] public CharacterBody2D? CharacterBody2D;
    
    readonly HashSet<Node2D> CollidingNodes = new();
    readonly HashSet<Node2D> CheckingCollidingNodes = new();
    readonly HashSet<Node2D> AlreadyCheckedCollidingNodes = new();

    public event Action<Node2D, KinematicCollision2D>? OnEnter;
    public event Action<Node2D, KinematicCollision2D>? OnStay;
    public event Action<Node2D>? OnExit;

    public override void _PhysicsProcess(double delta)
    {
        if (CharacterBody2D == null)
        {
            return;
        }
        
        AlreadyCheckedCollidingNodes.Clear();
        CheckingCollidingNodes.Clear();
        CheckingCollidingNodes.AddRange(CollidingNodes);
        
        for (int i = 0; i < CharacterBody2D.GetSlideCollisionCount(); i++)
        {
            // TODO: Review, this allocates like crazy lol
            KinematicCollision2D kinematicCollision2D = CharacterBody2D.GetSlideCollision(i);
            GodotObject collider = kinematicCollision2D.GetCollider();

            if (collider is not Node2D node2D)
            {
                return;
            }

            bool alreadyChecked = AlreadyCheckedCollidingNodes.Contains(node2D);

            if (alreadyChecked)
            {
                continue;
            }

            AlreadyCheckedCollidingNodes.Add(node2D);
                
            bool existed = CheckingCollidingNodes.Remove(node2D);

            if (!existed)
            {
                CollidingNodes.Add(node2D);
                OnEnter?.Invoke(node2D, kinematicCollision2D);
            }
            else
            {
                OnStay?.Invoke(node2D, kinematicCollision2D);
            }
        }

        foreach (Node2D checking in CheckingCollidingNodes)
        {
            CollidingNodes.Remove(checking);
            OnExit?.Invoke(checking);
        }
    }
}