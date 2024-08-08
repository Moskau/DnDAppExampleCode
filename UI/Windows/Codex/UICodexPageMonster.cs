using DnD.Content;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DnD.UI
{
    public class UICodexPageMonster : UICodexPage
    {
        //Codex Page Header
        [SerializeField]
        private TextMeshProUGUI m_acText;
        [SerializeField]
        private TextMeshProUGUI m_hpText;
        [SerializeField]
        private TextMeshProUGUI m_crText;

        //Codex Page Top
        [SerializeField]
        protected UIImageDownloader m_contentImage;

        //Codex Page Top
        [SerializeField]
        private TextMeshProUGUI m_strText;
        [SerializeField]
        private TextMeshProUGUI m_dexText;
        [SerializeField]
        private TextMeshProUGUI m_constText;
        [SerializeField]
        private TextMeshProUGUI m_intText;
        [SerializeField]
        private TextMeshProUGUI m_wisText;
        [SerializeField]
        private TextMeshProUGUI m_chaText;

        //Codex Page Bottom
        [SerializeField]
        private TextMeshProUGUI m_speed;
        [SerializeField]
        private TextMeshProUGUI m_savingThrows;
        [SerializeField]
        private TextMeshProUGUI m_skills;
        [SerializeField]
        private TextMeshProUGUI m_senses;
        [SerializeField]
        private TextMeshProUGUI m_languages;
        [SerializeField]
        private TextMeshProUGUI m_traits;
        [SerializeField]
        private TextMeshProUGUI m_actions;
        [SerializeField]
        private TextMeshProUGUI m_legendaryActions;

        private DnDCreatureDefinition m_monsterDefinition;

        private const string URL_PATH = "https://www.aidedd.org/dnd/monstres.php?vo=";

        public override void UpdateCodexPage(DnDContentDefinition monsterDefinition)
        {
            this.gameObject.SetActive(true);

            m_monsterDefinition = monsterDefinition as DnDCreatureDefinition;

            m_contentName.text = m_monsterDefinition.m_name;
            m_contentDescription.text = m_monsterDefinition.m_description;

            StartCoroutine(m_contentImage.LoadImageFromURL(m_monsterDefinition.m_monster.img_url));

            m_acText.text = m_monsterDefinition.m_monster.armor_class.ToString();
            m_hpText.text = m_monsterDefinition.m_monster.hit_points.ToString();
            m_crText.text = m_monsterDefinition.m_monster.Challenge.ToString();

            //Atrributes
            m_strText.text = m_monsterDefinition.m_monster.STR + " " + m_monsterDefinition.m_monster.STR_mod;
            m_dexText.text = m_monsterDefinition.m_monster.DEX + " " + m_monsterDefinition.m_monster.DEX_mod;
            m_constText.text = m_monsterDefinition.m_monster.CON + " " + m_monsterDefinition.m_monster.CON_mod;
            m_intText.text = m_monsterDefinition.m_monster.INT + " " + m_monsterDefinition.m_monster.INT_mod;
            m_wisText.text = m_monsterDefinition.m_monster.WIS + " " + m_monsterDefinition.m_monster.WIS_mod;
            m_chaText.text = m_monsterDefinition.m_monster.CHA + " " + m_monsterDefinition.m_monster.CHA_mod;

            m_speed.text = m_monsterDefinition.m_monster.Speed;
            m_savingThrows.text = m_monsterDefinition.m_monster.saving_throws;
            m_skills.text = m_monsterDefinition.m_monster.Skills;
            m_senses.text = m_monsterDefinition.m_monster.Senses;
            m_languages.text = m_monsterDefinition.m_monster.Languages;

            m_traits.text = m_monsterDefinition.m_monster.Traits;
            m_actions.text = m_monsterDefinition.m_monster.Actions;
            if (m_monsterDefinition.m_monster.legendary_actions != null) m_legendaryActions.text = m_monsterDefinition.m_monster.legendary_actions;
        }

        public void OnInspect()
        {
            Application.OpenURL(URL_PATH + m_contentName.text);
        }

        public void OnBackButton()
        {
            this.gameObject.SetActive(false);
        }
    }
}


