using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;

namespace Lcx.Pmt.Entity
{
    public unsafe partial class All
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Event
        {
            public short VanishTime;                // vanish time (?)
            public ushort x;                        // X coordinate on the map
            public ushort y;                        // Y coordinate on the map
            public short Layer;                     // layer value
            public ushort TriggerScript;            // Trigger script entry
            public ushort AutoScript;               // Auto script entry
            public short State;                     // state of this object
            public ushort TriggerMode;              // trigger mode
            public ushort SpriteNum;                // number of the sprite
            public ushort nSpriteFrames;            // total number of frames of the sprite
            public ushort Direction;                // direction
            public ushort CurrentFrameNum;          // current frame number
            public ushort TriggerIdleFrame;         // count of idle frames, used by trigger script
            public ushort SpritePtrOffset;          // FIXME: ???
            public ushort nSpriteFramesAuto;        // total number of frames of the sprite, used by auto script
            public ushort AutoIdleFrame;            // count of idle frames, used by auto script
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Scene
        {
            public ushort MapNum;               // number of the map
            public ushort ScriptOnEnter;        // when entering this scene, execute script from here
            public ushort ScriptOnTeleport;     // when teleporting out of this scene, execute script from here
            public ushort EventObjectIndex;     // event objects in this scene begins from number wEventObjectIndex + 1
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HeroCommon
        {
            fixed ushort Reserved[2];               // always zero
            public ushort ScriptOnFriendDeath;      // when friends in party dies, execute script from here
            public ushort ScriptOnDying;            // when dying, execute script from here
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ItemDos
        {
            public ushort Bitmap;               // bitmap number in BALL.MKF
            public ushort Price;                // price
            public ushort ScriptOnUse;          // script executed when using this item
            public ushort ScriptOnEquip;        // script executed when equipping this item
            public ushort ScriptOnThrow;        // script executed when throwing this item to enemy
            public ushort Flags;                // flags
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ItemWin
        {
            public ushort Bitmap;               // bitmap number in BALL.MKF
            public ushort Price;                // price
            public ushort ScriptOnUse;          // script executed when using this item
            public ushort ScriptOnEquip;        // script executed when equipping this item
            public ushort ScriptOnThrow;        // script executed when throwing this item to enemy
            public ushort ScriptDesc;           // description script
            public ushort Flags;                // flags
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MagicDos
        {
            public ushort MagicNumber;          // magic number, according to DATA.MKF #3
            readonly ushort Reserved1;                   // always zero
            public ushort ScriptOnSuccess;      // when magic succeed, execute script from here
            public ushort ScriptOnUse;          // when use this magic, execute script from here
            readonly ushort Reserved2;                   // always zero
            public ushort Flags;                // flags
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MagicWin
        {
            public ushort MagicNumber;          // magic number, according to DATA.MKF #3
            readonly ushort Reserved1;                   // always zero
            public ushort ScriptOnSuccess;      // when magic succeed, execute script from here
            public ushort ScriptOnUse;          // when use this magic, execute script from here
            public ushort ScriptDesc;           // description script
            public ushort Flags;                // flags
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EnemyCommon
        {
            public ushort EnemyID;                  // ID of the enemy, according to DATA.MKF #1.
                                                    // Also indicates the bitmap number in ABC.MKF.
            public ushort ResistanceToSorcery;      // resistance to sorcery and poison (0 min, 10 max)
            public ushort ScriptOnTurnStart;        // script executed when turn starts
            public ushort ScriptOnBattleEnd;        // script executed when battle ends
            public ushort ScriptOnReady;            // script executed when the enemy is ready
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PoisonCommon
        {
            public ushort PoisonLevel;      // level of the poison
            public ushort Color;            // color of avatars
            public ushort PlayerScript;     // script executed when player has this poison (per round)
            public ushort Reserved;         // always zero
            public ushort EnemyScript;      // script executed when enemy has this poison (per round)
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct ObjectDos
        {
            [FieldOffset(0)]
            public fixed ushort Data[6];
            [FieldOffset(0)]
            public HeroCommon Hero;
            [FieldOffset(0)]
            public ItemDos Item;
            [FieldOffset(0)]
            public MagicDos Magic;
            [FieldOffset(0)]
            public EnemyCommon Enemy;
            [FieldOffset(0)]
            public PoisonCommon Poison;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct ObjectWin
        {
            [FieldOffset(0)]
            public fixed ushort Data[7];
            [FieldOffset(0)]
            public HeroCommon Hero;
            [FieldOffset(0)]
            public ItemWin Item;
            [FieldOffset(0)]
            public MagicWin Magic;
            [FieldOffset(0)]
            public EnemyCommon Enemy;
            [FieldOffset(0)]
            public PoisonCommon Poison;
        }
    }
}
