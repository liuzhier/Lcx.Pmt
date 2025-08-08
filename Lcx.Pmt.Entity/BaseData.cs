using System.Runtime.InteropServices;

namespace Lcx.Pmt.Entity
{
    public unsafe partial class All
    {
        public const int
            MaxShopItem = 9,
            MagicElementalNum = 5,
            MaxEnemysInTem = 5,
            MaxHero = 6,
            MaxHeroEquipments = 6,
            MaxHeroMagic = 32;

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Shop
        {
            public fixed short Item[MaxShopItem];
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Enemy
        {
            public ushort IdleFrames;               // total number of frames when idle
            public ushort MagicFrames;              // total number of frames when using magics
            public ushort AttackFrames;             // total number of frames when doing normal attack
            public ushort IdleAnimSpeed;            // speed of the animation when idle
            public ushort ActWaitFrames;            // FIXME: ???
            public ushort YPosOffset;
            public short AttackSound;               // sound played when this enemy uses normal attack
            public short ActionSound;               // FIXME: ???
            public short MagicSound;                // sound played when this enemy uses magic
            public short DeathSound;                // sound played when this enemy dies
            public short CallSound;                 // sound played when entering the battle
            public short Health;                    // total HP of the enemy
            public ushort Exp;                      // How many EXPs we'll get for beating this enemy
            public ushort Cash;                     // how many cashes we'll get for beating this enemy
            public short Level;                     // this enemy's level
            public short Magic;                     // this enemy's magic number
            public short MagicRate;                 // chance for this enemy to use magic
            public short AttackEquivItem;           // equivalence item of this enemy's normal attack
            public short AttackEquivItemRate;       // chance for equivalence item
            public short StealItem;                 // which item we'll get when stealing from this enemy
            public short nStealItem;                // total amount of the items which can be stolen
            public short AttackStrength;            // normal attack strength
            public short MagicStrength;             // magical attack strength
            public short Defense;                   // resistance to all kinds of attacking
            public short Dexterity;                 // dexterity
            public short FleeRate;                  // chance for successful fleeing
            public short PoisonResistance;          // resistance to poison
            public fixed short ElemResistance[MagicElementalNum];       // resistance to elemental magics
            public short PhysicalResistance;        // resistance to physical attack
            public ushort DualMove;                 // whether this enemy can do dual move or not
            public ushort CollectValue;             // value for collecting this enemy for items
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct EnemyTeam
        {
            public fixed short EnemyId[MaxEnemysInTem];
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct ElementalResistance
        {
            fixed ushort data[Lenght];

            public const ushort LenLow = MaxHero;
            public const ushort LenHigh = MagicElementalNum;
            public const ushort Lenght = LenLow * LenHigh;
            public ushort this[int index, int index2]
            {
                get
                {
                    Util.CheckoutArrayIndex(Lenght, ref index, ref index2);

                    return data[index * LenHigh + index2];
                }
                set
                {
                    Util.CheckoutArrayIndex(Lenght, ref index, ref index2);

                    data[index * LenHigh + index2] = value;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct HeroEquipment
        {
            fixed ushort data[Lenght];

            public const ushort LenLow = MaxHero;
            public const ushort LenHigh = MaxHeroMagic;
            public const ushort Lenght = LenLow * LenHigh;
            public ushort this[int index, int index2]
            {
                get
                {
                    Util.CheckoutArrayIndex(Lenght, ref index, ref index2);

                    return data[index * MaxHeroEquipments + index2];
                }
                set
                {
                    Util.CheckoutArrayIndex(Lenght, ref index, ref index2);

                    data[index * MaxHeroEquipments + index2] = value;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct HeroMagic
        {
            fixed ushort data[Lenght];

            public const ushort LenLow = MaxHero;
            public const ushort LenHigh = MagicElementalNum;
            public const ushort Lenght = LenLow * LenHigh;
            public ushort this[int index, int index2]
            {
                get
                {
                    Util.CheckoutArrayIndex(Lenght, ref index, ref index2);

                    return data[index * LenHigh + index2];
                }
                set
                {
                    Util.CheckoutArrayIndex(Lenght, ref index, ref index2);

                    data[index * LenHigh + index2] = value;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Hero
        {
            public ushort Avatar;               // avatar (shown in status view)
            public ushort SpriteNumInBattle;    // sprite displayed in battle (in F.MKF)
            public ushort SpriteNum;            // sprite displayed in normal scene (in MGO.MKF)
            public ushort Name;                 // name of player class (in public ushort.DAT)
            public ushort AttackAll;            // whether player can attack everyone in a bulk or not
            public ushort Unknown1;             // FIXME: ???
            public ushort Level;                // level
            public ushort MaxHP;                // maximum HP
            public ushort MaxMP;                // maximum MP
            public ushort HP;                   // current HP
            public ushort MP;                   // current MP
            public HeroEquipment Equipment;     // equipments
            public ushort AttackStrength;       // normal attack strength
            public ushort MagicStrength;        // magical attack strength
            public ushort Defense;              // resistance to all kinds of attacking
            public ushort Dexterity;            // dexterity
            public ushort FleeRate;             // chance of successful fleeing
            public ushort PoisonResistance;     // resistance to poison
            public ElementalResistance ElementalResistance;     // resistance to elemental magics
            public ushort Unknown2;             // FIXME: ???
            public ushort Unknown3;             // FIXME: ???
            public ushort Unknown4;             // FIXME: ???
            public ushort CoveredBy;            // who will cover me when I am low of HP or not sane
            public HeroMagic Magic;             // magics
            public ushort WalkFrames;           // walk frame (???)
            public ushort CooperativeMagic;     // cooperative magic
            public ushort Unknown5;             // FIXME: ???
            public ushort Unknown6;             // FIXME: ???
            public ushort DeathSound;           // sound played when player dies
            public ushort AttackSound;          // sound played when player attacks
            public ushort WeaponSound;          // weapon sound (???)
            public ushort CriticalSound;        // sound played when player make critical hits
            public ushort MagicSound;           // sound played when player is casting a magic
            public ushort CoverSound;           // sound played when player cover others
            public ushort DyingSound;           // sound played when player is dying
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SummonEffect
        {
            public short LayerOffset;       // limited to non-summon magic.
                                            // actual layer: PAL_Y(pos) + wYOffset + wMagicLayerOffset
            public short Speed;             // type of this magic
            public ushort KeepEffect;       // FIXME: ???
            public ushort FireDelay;        // start frame of the magic fire stage
            public ushort EffectTimes;      // total times of effect
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MagicEffect
        {
            public ushort SpriteNum;        // summon effect sprite (in F.MKF)
            public ushort IdleFrames;       // total number of frames when idle
            public ushort MagicFrames;      // total number of frames when using magics
            public ushort AttackFrames;     // total number of frames when doing normal attack
            public ushort ColorShift;       // total times of effect
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MagicEffectAll
        {
            public MagicEffect MagicEffect;         // non-summon magic plays an animation
            public SummonEffect SummonEffect;       // summoning magic animation plays.
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Magic
        {
            public ushort Effect;                   // effect sprite
            public ushort Type;                     // type of this magic
            public ushort XOffset;
            public ushort YOffset;
            public MagicEffectAll EffectAll;        // magic animation plays
            public ushort Shake;                    // shake screen
            public ushort Wave;                     // wave screen
            public ushort Unknown;                  // FIXME: ???
            public ushort CostMP;                   // MP cost
            public ushort BaseDamage;               // base damage
            public ushort Elemental;                // elemental (0 = No Elemental, last = poison)
            public short Sound;                     // sound played when using this magic
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct BattleField
        {
            public ushort ScreenWave;                                   // level of screen waving
            public fixed ushort ElementalEffect[MagicElementalNum];     // effect of attributed magics
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct LevelUpMagic
        {
            public ushort Level;        // level reached
            public ushort Magic;        // magic learned
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct BattleEffectIndex
        {
            fixed ushort data[Lenght];

            public const ushort LenLow = MaxHero;
            public const ushort LenHigh = MagicElementalNum;
            public const ushort Lenght = LenLow * LenHigh;
            public ushort this[int index, int index2]
            {
                get
                {
                    Util.CheckoutArrayIndex(Lenght, ref index, ref index2);

                    return data[index * LenHigh + index2];
                }
                set
                {
                    Util.CheckoutArrayIndex(Lenght, ref index, ref index2);

                    data[index * LenHigh + index2] = value;
                }
            }
        }
    }
}
