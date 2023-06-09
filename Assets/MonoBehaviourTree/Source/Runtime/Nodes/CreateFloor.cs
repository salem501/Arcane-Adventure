using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBT;
using UnityEngine.Tilemaps;

namespace MBT
{
  // Empty Menu attribute prevents Node to show up in "Add Component" menu.
  [AddComponentMenu("")]
  // Register node in visual editor node finder
  [MBTNode(name = "PCG/CreateTile")]
  public class CreateFloor : Leaf
  {
      // These two methods are optional, override only when needed
      // public override void OnAllowInterrupt() {}
      // public override void OnEnter() {}

      // This is called every tick as long as node is executed
      public override NodeResult Execute()
      {
          Blackboard blackboard = behaviourTree.GetComponent<Blackboard>();
          
          Vector2Int pos = blackboard.GetVariable<Vector2IntVariable>("position").Value;
          Tilemap map = blackboard.GetVariable<TilemapVariable>("map").Value;
          TileBase floorTile = blackboard.GetVariable<TileBaseVariable>("floorTile").Value;
          
          map.SetTile((Vector3Int) pos, floorTile);
          
          return NodeResult.success;
      }

      // These two methods are optional, override only when needed
      // public override void OnExit() {}
      // public override void OnDisallowInterrupt() {}

  }
}