using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DnD.Content
{
    [Serializable]
    public class DnDPlayerDefinition : DnDContentDefinition
    {
        private string player_age;
        private string player_height;
        private string player_weight;
        private string player_eyes;
        private string player_skin;
        private string player_hair;
        private string player_class;
        private string player_level;
        private string player_background;
        private string player_alignmentl;
        private string player_exp;
        private string player_race;
        private string player_armor_class;
        private Attributes player_attributes;
        private SavingThrows player_saving_throws;
        private Skills player_skills;
        private Proficiencies player_proficiencies;
        private string player_init;
        private string player_speed;
        private string player_total_hp;
        private string player_current_hp;
        private List<string> player_languages;
        private List<string> player_spells;
        private List<string> player_inventory;
        private List<string> player_equipment;
    }
}
