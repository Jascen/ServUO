namespace Server.Items
{
    public static partial class RunicReforging
    {
        #region Tables

        #region All

        public static int[][] DexIntTable = {
            new[] { 3, 4, 4, 4, 5, 6, 7 },
            new[] { 4, 4, 5, 5, 5, 6, 2 },
            new int[] {  },
            new[] { 4, 4, 5, 5, 5, 6, 1 },
            new[] { 4, 4, 5, 6, 7, 7, 8 },
            new[] { 5, 2, 3, 5, 8, 8, 8 },
        };

        public static int[][] DurabilityTable = {
            new[] { 90, 100, 0, 0, 0, 0, 0 },
            new[] { 110, 140, 0, 0, 0, 0, 0 },
            new[] { 150, 150, 0, 0, 0, 0, 0 },
            new[] { 100, 140, 0, 0, 0, 0, 0 },
            new[] { 110, 140, 0, 0, 0, 0, 0 },
            new[] { 150, 150, 0, 0, 0, 0, 0 },
        };

        public static int[][] EaterTable = {
            new[] { 9, 12, 12, 15, 15, 15, 15 },
            new int[] {  },
            new int[] {  },
            new int[] {  },
            new[] { 12, 15, 15, 15, 15, 15, 15 },
            new[] { 15, 15, 15, 15, 15, 15, 15 },
        };

        public static int[][] LowerStatReqTable = {
            new[] { 60, 70, 80, 100, 100, 100, 100 },
            new[] { 80, 100, 100, 100, 100, 100, 100 },
            new[] { 100, 100, 100, 100, 100, 100, 100 },
            new int[] {  },
            new int[] {  },
            new[] { 100, 100, 100, 100, 100, 100, 100 },
        };

        public static int[][] ResistTable = {
            new[] { 10, 15, 15, 15, 15, 15, 15 },
            new[] { 15, 15, 15, 10, 15, 15, 5 },
            new[] { 10, 15, 15, 15, 15, 15, 15 },
            new[] { 15, 15, 15, 20, 15, 15, 5 },
            new[] { 10, 15, 15, 15, 15, 15, 15 },
            new[] { 15, 15, 15, 10, 15, 15, 5 },
            new[] { 15, 15, 5, 10, 15, 15, 10 },
            new[] { 5, 5, 10, 20, 10, 15, 15 },
        };

        public static int[][] SelfRepairTable = {
            new[] { 2, 4, 0, 0, 0, 0, 0 },
            new[] { 5, 5, 0, 0, 0, 0, 0 },
            new[] { 2, 4, 0, 0, 0, 0, 0 },
            new[] { 2, 4, 0, 0, 0, 0, 0 },
            new[] { 5, 5, 0, 0, 0, 0, 0 },
            new[] { 5, 5, 0, 0, 0, 0, 0 },
        };

        #endregion All

        #region Weapon Tables

        public static int[][] HitsAndManaLeechTable = {
            new[] { 15, 25, 25, 30, 35, 50, 35 },
            new[] { 25, 25, 30, 35, 50, 35, 50 },
            new[] { 30, 35, 35, 35, 35, 50, 50 },
            new int[] {  },
            new[] { 50, 25, 30, 35, 50, 50, 50 },
            new[] { 30, 35, 35, 35, 35, 50, 50 },
                };

        public static int[][] HitStamLeechTable = {
            new[] { 15, 25, 25, 30, 35, 50, 35 },
            new[] { 25, 25, 30, 35, 50, 35, 50 },
            new[] { 30, 35, 35, 35, 35, 50, 50 },
            new int[] {  },
            new[] { 50, 25, 30, 35, 50, 50, 50 },
            new[] { 30, 35, 35, 35, 35, 50, 50 },
                };

        // Hit magic, area, HLA
        public static int[][] HitWeaponTable1 = {
            new[] { 15, 25, 25, 30, 35, 50, 35 },
            new[] { 25, 25, 30, 35, 50, 35, 50 },
            new[] { 30, 35, 35, 35, 35, 50, 50 },
            new int[] {  },
            new[] { 50, 25, 30, 35, 50, 50, 50 },
            new[] { 30, 35, 35, 35, 35, 50, 50 },
        };

        // hit fatigue, mana drain, HLD
        public static int[][] HitWeaponTable2 = {
            new[] { 15, 25, 25, 30, 35, 50, 35 },
            new[] { 25, 25, 30, 35, 50, 35, 50 },
            new[] { 30, 35, 35, 35, 35, 50, 50 },
            new int[] {  },
            new[] { 50, 25, 30, 35, 50, 50, 50 },
            new[] { 30, 35, 35, 35, 35, 50, 50 },
        };

        public static int[][] LuckTable = {
            new[] { 80, 100, 100, 120, 140, 150, 150 },
            new[] { 100, 120, 140, 150, 150, 150, 150 },
            new[] { 130, 150, 150, 150, 150, 150, 150 },
            new[] { 100, 120, 140, 150, 150, 150, 150 },
            new[] { 100, 120, 140, 150, 150, 150, 150 },
            new[] { 150, 150, 150, 150, 150, 150, 150 },
        };

        public static int[][] MageWeaponTable = {
            new[] { 25, 20, 20, 20, 20, 15, 15 },
            new[] { 20, 20, 20, 15, 15, 15, 15 },
            new[] { 20, 15, 15, 15, 15, 15, 15 },
            new int[] {  },
            new[] { 20, 20, 20, 15, 15, 15, 15 },
            new[] { 15, 15, 15, 15, 15, 15, 15 },
        };

        public static int[][] WeaponDamageTable = {
            new[] { 30, 50, 50, 60, 70, 70, 70 },
            new[] { 50, 60, 70, 70, 70, 70, 70 },
            new[] { 70, 70, 70, 70, 70, 70, 70 },
            new int[] {  },
            new[] { 50, 60, 70, 70, 70, 70, 70 },
            new[] { 20, 30, 30, 35, 40, 40, 70 },
        };

        public static int[][] WeaponDCITable = {
            new[] { 10, 15, 15, 15, 20, 20, 20 },
            new[] { 15, 15, 20, 20, 20, 20, 20 },
            new[] { 20, 20, 20, 20, 20, 20, 20 },
            new int[] {  },
            new[] { 15, 15, 20, 20, 20, 20, 20 },
            new[] { 20, 20, 20, 20, 20, 20, 20 },
        };

        public static int[][] WeaponEnhancePots = {
            new[] { 5, 10, 10, 10, 10, 15, 15 },
            new[] { 10, 10, 10, 15, 15, 15, 15 },
            new[] { 10, 15, 15, 15, 15, 15, 15 },
            new int[] {  },
            new[] { 10, 10, 10, 15, 15, 15, 15 },
            new[] { 15, 15, 15, 15, 15, 15, 15 },
        };

        public static int[][] WeaponHCITable = {
            new[] { 5, 10, 15, 15, 15, 20, 20 },
            new[] { 15, 15, 15, 20, 20, 20, 20 },
            new[] { 15, 20, 20, 20, 20, 20, 20 },
            new int[] {  },
            new[] { 15, 15, 20, 20, 20, 20, 20 },
            new[] { 20, 20, 20, 20, 20, 20, 20 },
        };

        public static int[][] WeaponHitsTable = {
            new[] { 2, 3, 3, 3, 4, 4, 4 },
            new[] { 3, 3, 4, 4, 4, 4, 4 },
            new[] { 4, 4, 4, 4, 4, 4, 4 },
            new int[] { },
            new[] { 3, 3, 4, 4, 4, 4, 4 },
            new[] { 4, 4, 4, 4, 4, 4, 4 },
        };

        public static int[][] WeaponRegenTable = {
            new[] { 2, 4, 4, 4, 5, 5, 5 },
            new[] { 4, 4, 5, 5, 5, 5, 5 },
            new[] { 5, 5, 5, 5, 5, 5, 5 },
            new int[] { },
            new[] { 4, 4, 5, 5, 5, 5, 5 },
            new[] { 5, 5, 5, 5, 5, 5, 5 },
        };

        public static int[][] WeaponStamManaLMCTable = {
            new[] { 2, 4, 4, 4, 5, 5, 5 },
            new[] { 4, 4, 5, 5, 5, 5, 5 },
            new[] { 5, 5, 5, 5, 5, 5, 5 },
            new int[] { },
            new[] { 4, 4, 5, 5, 5, 5, 5 },
            new[] { 5, 5, 5, 5, 5, 5, 5 },
        };

        public static int[][] WeaponStrTable = {
            new[] { 2, 4, 4, 4, 5, 5, 5 },
            new[] { 4, 4, 5, 5, 5, 5, 5 },
            new[] { 5, 5, 5, 5, 5, 5, 5 },
            new int[] {  },
            new[] { 4, 4, 5, 5, 5, 5, 5 },
            new[] { 5, 5, 5, 5, 5, 5, 5 },
        };

        public static int[][] WeaponVelocityTable = {
            new[] { 25, 35, 40, 40, 40, 45, 50 },
            new[] { 40, 40, 40, 45, 50, 50, 50 },
            new[] { 40, 45, 50, 50, 50, 50, 50 },
            new int[] {  },
            new[] { 40, 40, 40, 45, 50, 50, 50 },
            new[] { 45, 50, 50, 50, 50, 50, 50 },
        };

        public static int[][] WeaponWeaponSpeedTable = {
            new[] { 20, 30, 30, 35, 40, 40, 40 },
            new[] { 5, 10, 15, 15, 15, 20, 20 },
            new[] { 15, 15, 15, 20, 20, 20, 20 },
            new int[] {  },
            new[] { 20, 30, 30, 35, 40, 40, 40 },
            new[] { 15, 15, 15, 20, 20, 20, 20 },
        };

        #endregion Weapon Tables

        #region Ranged Weapons

        public static int[][] RangedDCITable = {
            new int[] {  },
            new int[] {  },
            new int[] {  },
            new int[] {  },
            new[] { 5, 10, 15, 15, 15, 20, 20 },
            new[] { 15, 15, 15, 20, 20, 20, 20 },
        };

        public static int[][] RangedHCITable = {
            new[] { 5, 10, 15, 15, 15, 20, 20 },
            new[] { 15, 15, 15, 20, 20, 20, 20 },
            new[] { 15, 20, 20, 20, 20, 20, 20 },
            new int[] {  },
            new[] { 5, 10, 15, 15, 15, 20, 20 },
            new[] { 15, 15, 15, 20, 20, 20, 20 },
        };

        public static int[][] RangedLuckTable = {
            new[] { 90, 120, 120, 140, 170, 170, 170 },
            new[] { 120, 140, 160, 170, 170, 170, 170 },
            new[] { 160, 170, 170, 170, 170, 170, 170 },
            new int[] {  },
            new[] { 120, 140, 160, 170, 170, 170, 170 },
            new[] { 170, 170, 170, 170, 170, 170, 170 },
        };

        #endregion Ranged Weapons

        #region Armor Tables

        public static int[][] ArmorCastingFocusTable = {
            new[] { 1, 2, 2, 2, 3, 3, 3 },
            new[] { 2, 2, 3, 3, 3, 3, 3 },
            new[] { 3, 3, 3, 3, 3, 3, 3 },
            new[] { 2, 2, 3, 3, 3, 3, 3 },
            new[] { 2, 2, 3, 3, 3, 3, 3 },
            new[] { 3, 3, 3, 3, 3, 3, 3 },
        };

        public static int[][] ArmorEnhancePotsTable = {
            new[] { 2, 2, 3, 3, 3, 3, 3 },
            new[] { 3, 3, 3, 3, 3, 3, 3 },
            new int[] {  },
            new[] { 3, 3, 3, 3, 3, 3, 3 },
            new int[] {  },
            new[] { 5, 10, 10, 10, 10, 15, 15 },
        };

        public static int[][] ArmorHCIDCITable = {
            new[] { 2, 2, 3, 3, 3, 3, 3 },
            new[] { 3, 3, 3, 3, 3, 3, 3 },
            new int[] {  },
            new[] { 4, 4, 5, 5, 5, 5, 5 },
            new[] { 2, 2, 3, 3, 3, 3, 3 },
            new[] { 5, 5, 5, 5, 5, 5, 5 },
        };

        public static int[][] ArmorHitsTable = {
            new[] { 1, 2, 2, 2, 3, 3, 3 },
            new[] { 4, 4, 5, 5, 5, 5, 5 },
            new[] { 2, 2, 3, 3, 3, 3, 3 },
            new[] { 4, 4, 5, 5, 5, 5, 5 },
            new int[] {  },
            new[] { 5, 5, 5, 5, 5, 5, 5 },
        };

        public static int[][] ArmorRegenTable = {
            new[] { 1, 2, 2, 2, 3, 3, 3 },
            new[] { 1, 2, 2, 2, 3, 3, 3 },
            new[] { 1, 2, 2, 2, 3, 3, 3 },
            new[] { 2, 2, 3, 3, 3, 3, 3 },
            new[] { 2, 2, 3, 3, 3, 3, 3 },
            new[] { 3, 3, 3, 3, 3, 3, 3 },
        };

        public static int[][] ArmorStamManaLMCTable = {
            new[] { 4, 8, 8, 8, 10, 10, 10 },
            new[] { 8, 8, 10, 10, 10, 10, 10 },
            new[] { 10, 10, 10, 10, 10, 10, 10 },
            new[] { 8, 8, 10, 10, 10, 10, 10 },
            new[] { 8, 8, 10, 10, 10, 10, 10 },
            new[] { 10, 10, 10, 10, 10, 10, 10 },
        };

        public static int[][] ArmorStrTable = {
            new[] { 3, 4, 4, 4, 5, 6, 7 },
            new[] { 4, 4, 5, 5, 5, 6, 2 },
            new[] { 5, 5, 5, 5, 5, 6, 2 },
            new int[] {  },
            new[] { 4, 4, 5, 6, 7, 7, 8 },
            new[] { 5, 2, 3, 5, 8, 8, 8 },
        };

        public static int[][] LowerRegTable = {
            new[] { 10, 20, 20, 20, 25, 25, 25 },
            new[] { 20, 20, 25, 25, 25, 25, 25 },
            new[] { 25, 25, 25, 25, 25, 25, 25 },
            new[] { 20, 20, 25, 25, 25, 25, 25 },
            new int[] {  },
            new[] { 25, 25, 25, 25, 25, 25, 25 },
        };

        public static int[][] ShieldSoulChargeTable = {
            new[] { 15, 20, 20, 20, 25, 25, 25 },
            new[] { 20, 20, 25, 30, 30, 30, 30 },
            new[] { 25, 30, 30, 30, 30, 30, 30 },
            new int[] {  },
            new[] { 20, 20, 25, 30, 30, 30, 30 },
            new[] { 25, 30, 30, 30, 30, 30, 30 },
        };

        public static int[][] ShieldWeaponSpeedTable = {
            new[] { 5, 5, 5, 5, 10, 10, 10 },
            new[] { 5, 5, 10, 10, 10, 10, 10 },
            new[] { 10, 10, 10, 10, 10, 10, 10 },
            new int[] {  },
            new[] { 5, 5, 10, 10, 10, 10, 10 },
            new[] { 10, 10, 10, 10, 10, 10, 10 },
        };

        #endregion Armor Tables

        #endregion Tables
    }
}
