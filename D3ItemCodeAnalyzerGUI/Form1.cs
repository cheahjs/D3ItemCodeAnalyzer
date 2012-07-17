using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace D3ItemCodeAnalyzerGUI
{
    public partial class Form1 : Form
    {
        static Regex ItemName = new Regex(@"\|h\[(.+)\]\|h");
        static Dictionary<string, string> Affixes = new Dictionary<string, string>();
        static Dictionary<string, string> URLDict = new Dictionary<string, string>();
        #region Text files

        private const string URLS = @"http://www.d3lexicon.com/affix/all-stats-1-legendary AllStats 1 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-1-legendary AllStats1H 1 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-2-legendary AllStats1H 2 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-3-legendary AllStats1H 3 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-4-legendary AllStats1H 4 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-5-legendary AllStats1H 5 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-6-legendary AllStats1H 6 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-7-legendary AllStats1H 7 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-8-legendary AllStats1H 8 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-9-legendary AllStats1H 9 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-10-legendary AllStats1H 10 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-11-legendary AllStats1H 11 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-12-legendary AllStats1H 12 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-13-legendary AllStats1H 13 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-14-legendary AllStats1H 14 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-15-legendary AllStats1H 15 Legendary
http://www.d3lexicon.com/affix/all-stats-1h-16-legendary AllStats1H 16 Legendary
http://www.d3lexicon.com/affix/all-stats-2-legendary AllStats 2 Legendary
http://www.d3lexicon.com/affix/all-stats-3-legendary AllStats 3 Legendary
http://www.d3lexicon.com/affix/all-stats-4-legendary AllStats 4 Legendary
http://www.d3lexicon.com/affix/all-stats-5-legendary AllStats 5 Legendary
http://www.d3lexicon.com/affix/all-stats-6-legendary AllStats 6 Legendary
http://www.d3lexicon.com/affix/all-stats-7-legendary AllStats 7 Legendary
http://www.d3lexicon.com/affix/all-stats-8-legendary AllStats 8 Legendary
http://www.d3lexicon.com/affix/all-stats-9-legendary AllStats 9 Legendary
http://www.d3lexicon.com/affix/all-stats-10-legendary AllStats 10 Legendary
http://www.d3lexicon.com/affix/all-stats-11-legendary AllStats 11 Legendary
http://www.d3lexicon.com/affix/all-stats-12-legendary AllStats 12 Legendary
http://www.d3lexicon.com/affix/all-stats-13-legendary AllStats 13 Legendary
http://www.d3lexicon.com/affix/all-stats-14-legendary AllStats 14 Legendary
http://www.d3lexicon.com/affix/all-stats-15-legendary AllStats 15 Legendary
http://www.d3lexicon.com/affix/all-stats-16-legendary AllStats 16 Legendary
http://www.d3lexicon.com/affix/amplify-damage-i Amplify Damage I
http://www.d3lexicon.com/affix/anatomy-i Anatomy I
http://www.d3lexicon.com/affix/of-starlight ArcaneD 1
http://www.d3lexicon.com/affix/arcane-damage-1-fast ArcaneD 1 Fast
http://www.d3lexicon.com/affix/of-starlight-2 ArcaneD 2
http://www.d3lexicon.com/affix/arcane-damage-2-fast ArcaneD 2 Fast
http://www.d3lexicon.com/affix/of-starlight-3 ArcaneD 3
http://www.d3lexicon.com/affix/arcane-damage-3-fast ArcaneD 3 Fast
http://www.d3lexicon.com/affix/of-starlight-4 ArcaneD 4
http://www.d3lexicon.com/affix/arcane-damage-4-fast ArcaneD 4 Fast
http://www.d3lexicon.com/affix/of-starlight-5 ArcaneD 5
http://www.d3lexicon.com/affix/arcane-damage-5-fast ArcaneD 5 Fast
http://www.d3lexicon.com/affix/of-infinity ArcaneD 6
http://www.d3lexicon.com/affix/arcane-damage-6-fast ArcaneD 6 Fast
http://www.d3lexicon.com/affix/of-infinity-2 ArcaneD 7
http://www.d3lexicon.com/affix/arcane-damage-7-fast ArcaneD 7 Fast
http://www.d3lexicon.com/affix/of-infinity-3 ArcaneD 8
http://www.d3lexicon.com/affix/arcane-damage-8-fast ArcaneD 8 Fast
http://www.d3lexicon.com/affix/of-infinity-4 ArcaneD 9
http://www.d3lexicon.com/affix/arcane-damage-9-fast ArcaneD 9 Fast
http://www.d3lexicon.com/affix/of-the-void ArcaneD 10
http://www.d3lexicon.com/affix/arcane-damage-10-fast ArcaneD 10 Fast
http://www.d3lexicon.com/affix/of-the-void-2 ArcaneD 11
http://www.d3lexicon.com/affix/arcane-damage-11-fast ArcaneD 11 Fast
http://www.d3lexicon.com/affix/of-the-void-3 ArcaneD 12
http://www.d3lexicon.com/affix/arcane-damage-12-fast ArcaneD 12 Fast
http://www.d3lexicon.com/affix/of-the-void-4 ArcaneD 13
http://www.d3lexicon.com/affix/arcane-damage-13-fast ArcaneD 13 Fast
http://www.d3lexicon.com/affix/from-beyond ArcaneD 14
http://www.d3lexicon.com/affix/arcane-damage-14-fast ArcaneD 14 Fast
http://www.d3lexicon.com/affix/foreboding ArcanePowerOnCrit 1
http://www.d3lexicon.com/affix/foreboding-2 ArcanePowerOnCrit 2
http://www.d3lexicon.com/affix/foreboding-3 ArcanePowerOnCrit 3
http://www.d3lexicon.com/affix/ominous ArcanePowerOnCrit 4
http://www.d3lexicon.com/affix/ominous-2 ArcanePowerOnCrit 5
http://www.d3lexicon.com/affix/arcane-resist-01-legendary ArcaneResist 0.1 Legendary
http://www.d3lexicon.com/affix/arcane-resist-02-legendary ArcaneResist 0.2 Legendary
http://www.d3lexicon.com/affix/arcane-resist-03-legendary ArcaneResist 0.3 Legendary
http://www.d3lexicon.com/affix/warding ArcaneResist I
http://www.d3lexicon.com/affix/warding-2 ArcaneResist II
http://www.d3lexicon.com/affix/warding-3 ArcaneResist III
http://www.d3lexicon.com/affix/warding-4 ArcaneResist IV
http://www.d3lexicon.com/affix/nullifying ArcaneResist IX
http://www.d3lexicon.com/affix/beguiling ArcaneResist V
http://www.d3lexicon.com/affix/beguiling-2 ArcaneResist VI
http://www.d3lexicon.com/affix/beguiling-3 ArcaneResist VII
http://www.d3lexicon.com/affix/beguiling-4 ArcaneResist VIII
http://www.d3lexicon.com/affix/nullifying-2 ArcaneResist X
http://www.d3lexicon.com/affix/nullifying-3 ArcaneResist XI
http://www.d3lexicon.com/affix/eclipsing ArcaneResist XII
http://www.d3lexicon.com/affix/bandage-i Bandage I
http://www.d3lexicon.com/affix/black-market-i Black Market I
http://www.d3lexicon.com/affix/bloody Bleed 1
http://www.d3lexicon.com/affix/bleed-1-secondary Bleed 1 Secondary
http://www.d3lexicon.com/affix/bloody-2 Bleed 2
http://www.d3lexicon.com/affix/bleed-2-secondary Bleed 2 Secondary
http://www.d3lexicon.com/affix/bloody-3 Bleed 3
http://www.d3lexicon.com/affix/bleed-3-secondary Bleed 3 Secondary
http://www.d3lexicon.com/affix/bloody-4 Bleed 4
http://www.d3lexicon.com/affix/bleed-4-secondary Bleed 4 Secondary
http://www.d3lexicon.com/affix/wounding Bleed 5
http://www.d3lexicon.com/affix/bleed-5-secondary Bleed 5 Secondary
http://www.d3lexicon.com/affix/wounding-2 Bleed 6
http://www.d3lexicon.com/affix/bleed-6-secondary Bleed 6 Secondary
http://www.d3lexicon.com/affix/wounding-3 Bleed 7
http://www.d3lexicon.com/affix/bleed-7-secondary Bleed 7 Secondary
http://www.d3lexicon.com/affix/wounding-4 Bleed 8
http://www.d3lexicon.com/affix/bleed-8-secondary Bleed 8 Secondary
http://www.d3lexicon.com/affix/grisly Bleed 9
http://www.d3lexicon.com/affix/bleed-9-secondary Bleed 9 Secondary
http://www.d3lexicon.com/affix/grisly-2 Bleed 10
http://www.d3lexicon.com/affix/bleed-10-secondary Bleed 10 Secondary
http://www.d3lexicon.com/affix/grisly-3 Bleed 11
http://www.d3lexicon.com/affix/bleed-11-secondary Bleed 11 Secondary
http://www.d3lexicon.com/affix/exsanguinating-2 Bleed 12
http://www.d3lexicon.com/affix/bleed-12-secondary Bleed 12 Secondary
http://www.d3lexicon.com/affix/of-the-tortoise Block 1
http://www.d3lexicon.com/affix/block-1-secondary Block 1 Secondary
http://www.d3lexicon.com/affix/of-the-tortoise-2 Block 2
http://www.d3lexicon.com/affix/block-2-secondary Block 2 Secondary
http://www.d3lexicon.com/affix/of-deflection Block 3
http://www.d3lexicon.com/affix/block-3-secondary Block 3 Secondary
http://www.d3lexicon.com/affix/of-deflection-2 Block 4
http://www.d3lexicon.com/affix/block-4-secondary Block 4 Secondary
http://www.d3lexicon.com/affix/of-deflection-3 Block 5
http://www.d3lexicon.com/affix/block-5-secondary Block 5 Secondary
http://www.d3lexicon.com/affix/of-interception Block 6
http://www.d3lexicon.com/affix/block-6-secondary Block 6 Secondary
http://www.d3lexicon.com/affix/of-interception-2 Block 7
http://www.d3lexicon.com/affix/block-7-secondary Block 7 Secondary
http://www.d3lexicon.com/affix/of-interception-3 Block 8
http://www.d3lexicon.com/affix/block-8-secondary Block 8 Secondary
http://www.d3lexicon.com/affix/of-invulnerability Block 9
http://www.d3lexicon.com/affix/block-9-secondary Block 9 Secondary
http://www.d3lexicon.com/affix/cc-reduction-01-legendary CCReduction 0.1 Legendary
http://www.d3lexicon.com/affix/cc-reduction-02-legendary CCReduction 0.2 Legendary
http://www.d3lexicon.com/affix/cc-reduction-03-legendary CCReduction 0.3 Legendary
http://www.d3lexicon.com/affix/defiant CCReduction 1
http://www.d3lexicon.com/affix/defiant-2 CCReduction 2
http://www.d3lexicon.com/affix/defiant-3 CCReduction 3
http://www.d3lexicon.com/affix/rebellious CCReduction 4
http://www.d3lexicon.com/affix/rebellious-2 CCReduction 5
http://www.d3lexicon.com/affix/of-charged-bolt-cast-example Charged Bolt Cast I
http://www.d3lexicon.com/affix/charge-i Charge I
http://www.d3lexicon.com/affix/charm-i Charm I
http://www.d3lexicon.com/affix/of-winter ColdD 1
http://www.d3lexicon.com/affix/cold-damage-1-fast ColdD 1 Fast
http://www.d3lexicon.com/affix/of-winter-2 ColdD 2
http://www.d3lexicon.com/affix/cold-damage-2-fast ColdD 2 Fast
http://www.d3lexicon.com/affix/of-winter-3 ColdD 3
http://www.d3lexicon.com/affix/cold-damage-3-fast ColdD 3 Fast
http://www.d3lexicon.com/affix/of-winter-4 ColdD 4
http://www.d3lexicon.com/affix/cold-damage-4-fast ColdD 4 Fast
http://www.d3lexicon.com/affix/of-winter-5 ColdD 5
http://www.d3lexicon.com/affix/cold-damage-5-fast ColdD 5 Fast
http://www.d3lexicon.com/affix/of-shivers ColdD 6
http://www.d3lexicon.com/affix/cold-damage-6-fast ColdD 6 Fast
http://www.d3lexicon.com/affix/of-shivers-2 ColdD 7
http://www.d3lexicon.com/affix/cold-damage-7-fast ColdD 7 Fast
http://www.d3lexicon.com/affix/of-shivers-3 ColdD 8
http://www.d3lexicon.com/affix/cold-damage-8-fast ColdD 8 Fast
http://www.d3lexicon.com/affix/of-shivers-4 ColdD 9
http://www.d3lexicon.com/affix/cold-damage-9-fast ColdD 9 Fast
http://www.d3lexicon.com/affix/of-frost ColdD 10
http://www.d3lexicon.com/affix/cold-damage-10-fast ColdD 10 Fast
http://www.d3lexicon.com/affix/of-frost-2 ColdD 11
http://www.d3lexicon.com/affix/cold-damage-11-fast ColdD 11 Fast
http://www.d3lexicon.com/affix/of-frost-3 ColdD 12
http://www.d3lexicon.com/affix/cold-damage-12-fast ColdD 12 Fast
http://www.d3lexicon.com/affix/of-frost-4 ColdD 13
http://www.d3lexicon.com/affix/cold-damage-13-fast ColdD 13 Fast
http://www.d3lexicon.com/affix/of-the-avalanche ColdD 14
http://www.d3lexicon.com/affix/cold-damage-14-fast ColdD 14 Fast
http://www.d3lexicon.com/affix/cold-resist-01-legendary ColdResist 0.1 Legendary
http://www.d3lexicon.com/affix/cold-resist-02-legendary ColdResist 0.2 Legendary
http://www.d3lexicon.com/affix/cold-resist-03-legendary ColdResist 0.3 Legendary
http://www.d3lexicon.com/affix/nomadic ColdResist I
http://www.d3lexicon.com/affix/nomadic-2 ColdResist II
http://www.d3lexicon.com/affix/nomadic-3 ColdResist III
http://www.d3lexicon.com/affix/nomadic-4 ColdResist IV
http://www.d3lexicon.com/affix/thawing ColdResist IX
http://www.d3lexicon.com/affix/sheltering ColdResist V
http://www.d3lexicon.com/affix/sheltering-2 ColdResist VI
http://www.d3lexicon.com/affix/sheltering-3 ColdResist VII
http://www.d3lexicon.com/affix/sheltering-4 ColdResist VIII
http://www.d3lexicon.com/affix/thawing-2 ColdResist X
http://www.d3lexicon.com/affix/thawing-3 ColdResist XI
http://www.d3lexicon.com/affix/hearthfire ColdResist XII
http://www.d3lexicon.com/affix/crippling-shot-i Crippling Shot I
http://www.d3lexicon.com/affix/critical-chance-01-legendary CriticalChance 0.1 Legendary
http://www.d3lexicon.com/affix/iron CriticalChance I
http://www.d3lexicon.com/affix/iron-2 CriticalChance II
http://www.d3lexicon.com/affix/iron-3 CriticalChance III
http://www.d3lexicon.com/affix/critical-chance-iii-secondary CriticalChance III Secondary
http://www.d3lexicon.com/affix/critical-chance-ii-secondary CriticalChance II Secondary
http://www.d3lexicon.com/affix/critical-chance-i-secondary CriticalChance I Secondary
http://www.d3lexicon.com/affix/sawtooth CriticalChance IV
http://www.d3lexicon.com/affix/critical-chance-iv-secondary CriticalChance IV Secondary
http://www.d3lexicon.com/affix/flaying CriticalChance IX
http://www.d3lexicon.com/affix/critical-chance-ix-secondary CriticalChance IX Secondary
http://www.d3lexicon.com/affix/sawtooth-2 CriticalChance V
http://www.d3lexicon.com/affix/sawtooth-3 CriticalChance VI
http://www.d3lexicon.com/affix/lacerating CriticalChance VII
http://www.d3lexicon.com/affix/lacerating-2 CriticalChance VIII
http://www.d3lexicon.com/affix/critical-chance-viii-secondary CriticalChance VIII Secondary
http://www.d3lexicon.com/affix/critical-chance-vii-secondary CriticalChance VII Secondary
http://www.d3lexicon.com/affix/critical-chance-vi-secondary CriticalChance VI Secondary
http://www.d3lexicon.com/affix/critical-chance-v-secondary CriticalChance V Secondary
http://www.d3lexicon.com/affix/critical-damage-01-legendary CriticalD 0.1 Legendary
http://www.d3lexicon.com/affix/critical-damage-01-secondary-legendary CriticalD 0.1 Secondary Legendary
http://www.d3lexicon.com/affix/critical-damage-02-legendary CriticalD 0.2 Legendary
http://www.d3lexicon.com/affix/critical-damage-02-secondary-legendary CriticalD 0.2 Secondary Legendary
http://www.d3lexicon.com/affix/critical-damage-03-legendary CriticalD 0.3 Legendary
http://www.d3lexicon.com/affix/critical-damage-03-secondary-legendary CriticalD 0.3 Secondary Legendary
http://www.d3lexicon.com/affix/brutal CriticalD I
http://www.d3lexicon.com/affix/brutal-2 CriticalD II
http://www.d3lexicon.com/affix/brutal-3 CriticalD III
http://www.d3lexicon.com/affix/critical-damage-iii-secondary CriticalD III Secondary
http://www.d3lexicon.com/affix/critical-damage-ii-secondary CriticalD II Secondary
http://www.d3lexicon.com/affix/critical-damage-i-secondary CriticalD I Secondary
http://www.d3lexicon.com/affix/wicked CriticalD IV
http://www.d3lexicon.com/affix/critical-damage-iv-secondary CriticalD IV Secondary
http://www.d3lexicon.com/affix/deadly-3 CriticalD IX
http://www.d3lexicon.com/affix/critical-damage-ix-secondary CriticalD IX Secondary
http://www.d3lexicon.com/affix/wicked-2 CriticalD V
http://www.d3lexicon.com/affix/wicked-3 CriticalD VI
http://www.d3lexicon.com/affix/deadly CriticalD VII
http://www.d3lexicon.com/affix/deadly-2 CriticalD VIII
http://www.d3lexicon.com/affix/critical-damage-viii-secondary CriticalD VIII Secondary
http://www.d3lexicon.com/affix/critical-damage-vii-secondary CriticalD VII Secondary
http://www.d3lexicon.com/affix/critical-damage-vi-secondary CriticalD VI Secondary
http://www.d3lexicon.com/affix/critical-damage-v-secondary CriticalD V Secondary
http://www.d3lexicon.com/affix/merciless CriticalD X
http://www.d3lexicon.com/affix/critical-damage-x-secondary CriticalD X Secondary
http://www.d3lexicon.com/affix/damage-01-legendary Damage 0.1 Legendary
http://www.d3lexicon.com/affix/damage-02-legendary Damage 0.2 Legendary
http://www.d3lexicon.com/affix/damage-03-legendary Damage 0.3 Legendary
http://www.d3lexicon.com/affix/damage-bonus-arcane-1-legendary DamageBonusArcane 1 Legendary
http://www.d3lexicon.com/affix/damage-bonus-arcane-2-legendary DamageBonusArcane 2 Legendary
http://www.d3lexicon.com/affix/damage-bonus-arcane-3-legendary DamageBonusArcane 3 Legendary
http://www.d3lexicon.com/affix/damage-bonus-arcane-4-legendary DamageBonusArcane 4 Legendary
http://www.d3lexicon.com/affix/damage-bonus-cold-1-legendary DamageBonusCold 1 Legendary
http://www.d3lexicon.com/affix/damage-bonus-cold-2-legendary DamageBonusCold 2 Legendary
http://www.d3lexicon.com/affix/damage-bonus-cold-3-legendary DamageBonusCold 3 Legendary
http://www.d3lexicon.com/affix/damage-bonus-cold-4-legendary DamageBonusCold 4 Legendary
http://www.d3lexicon.com/affix/damage-bonus-fire-1-legendary DamageBonusFire 1 Legendary
http://www.d3lexicon.com/affix/damage-bonus-fire-2-legendary DamageBonusFire 2 Legendary
http://www.d3lexicon.com/affix/damage-bonus-fire-3-legendary DamageBonusFire 3 Legendary
http://www.d3lexicon.com/affix/damage-bonus-fire-4-legendary DamageBonusFire 4 Legendary
http://www.d3lexicon.com/affix/damage-bonus-holy-1-legendary DamageBonusHoly 1 Legendary
http://www.d3lexicon.com/affix/damage-bonus-holy-2-legendary DamageBonusHoly 2 Legendary
http://www.d3lexicon.com/affix/damage-bonus-holy-3-legendary DamageBonusHoly 3 Legendary
http://www.d3lexicon.com/affix/damage-bonus-holy-4-legendary DamageBonusHoly 4 Legendary
http://www.d3lexicon.com/affix/damage-bonus-lightning-1-legendary DamageBonusLightning 1 Legendary
http://www.d3lexicon.com/affix/damage-bonus-lightning-2-legendary DamageBonusLightning 2 Legendary
http://www.d3lexicon.com/affix/damage-bonus-lightning-3-legendary DamageBonusLightning 3 Legendary
http://www.d3lexicon.com/affix/damage-bonus-lightning-4-legendary DamageBonusLightning 4 Legendary
http://www.d3lexicon.com/affix/damage-bonus-poison-1-legendary DamageBonusPoison 1 Legendary
http://www.d3lexicon.com/affix/damage-bonus-poison-2-legendary DamageBonusPoison 2 Legendary
http://www.d3lexicon.com/affix/damage-bonus-poison-3-legendary DamageBonusPoison 3 Legendary
http://www.d3lexicon.com/affix/damage-bonus-poison-4-legendary DamageBonusPoison 4 Legendary
http://www.d3lexicon.com/affix/ferocious Damage I
http://www.d3lexicon.com/affix/ferocious-2 Damage II
http://www.d3lexicon.com/affix/ferocious-3 Damage III
http://www.d3lexicon.com/affix/savage Damage IV
http://www.d3lexicon.com/affix/violet DamageReductionArcane 1
http://www.d3lexicon.com/affix/violet-2 DamageReductionArcane 2
http://www.d3lexicon.com/affix/violet-3 DamageReductionArcane 3
http://www.d3lexicon.com/affix/violet-4 DamageReductionArcane 4
http://www.d3lexicon.com/affix/violet-5 DamageReductionArcane 5
http://www.d3lexicon.com/affix/violet-6 DamageReductionArcane 6
http://www.d3lexicon.com/affix/violet-7 DamageReductionArcane 7
http://www.d3lexicon.com/affix/violet-8 DamageReductionArcane 8
http://www.d3lexicon.com/affix/quartz DamageReductionArcane 9
http://www.d3lexicon.com/affix/quartz-2 DamageReductionArcane 10
http://www.d3lexicon.com/affix/opalite DamageReductionArcane 11
http://www.d3lexicon.com/affix/tanzanite DamageReductionArcane 12
http://www.d3lexicon.com/affix/azure DamageReductionCold 1
http://www.d3lexicon.com/affix/azure-2 DamageReductionCold 2
http://www.d3lexicon.com/affix/azure-3 DamageReductionCold 3
http://www.d3lexicon.com/affix/azure-4 DamageReductionCold 4
http://www.d3lexicon.com/affix/azure-5 DamageReductionCold 5
http://www.d3lexicon.com/affix/azure-6 DamageReductionCold 6
http://www.d3lexicon.com/affix/azure-7 DamageReductionCold 7
http://www.d3lexicon.com/affix/azure-8 DamageReductionCold 8
http://www.d3lexicon.com/affix/lapis DamageReductionCold 9
http://www.d3lexicon.com/affix/lapis-2 DamageReductionCold 10
http://www.d3lexicon.com/affix/cobalt DamageReductionCold 11
http://www.d3lexicon.com/affix/sapphire DamageReductionCold 12
http://www.d3lexicon.com/affix/crimson DamageReductionFire 1
http://www.d3lexicon.com/affix/crimson-2 DamageReductionFire 2
http://www.d3lexicon.com/affix/crimson-3 DamageReductionFire 3
http://www.d3lexicon.com/affix/crimson-4 DamageReductionFire 4
http://www.d3lexicon.com/affix/crimson-5 DamageReductionFire 5
http://www.d3lexicon.com/affix/crimson-6 DamageReductionFire 6
http://www.d3lexicon.com/affix/crimson-7 DamageReductionFire 7
http://www.d3lexicon.com/affix/crimson-8 DamageReductionFire 8
http://www.d3lexicon.com/affix/russet DamageReductionFire 9
http://www.d3lexicon.com/affix/russet-2 DamageReductionFire 10
http://www.d3lexicon.com/affix/garnet DamageReductionFire 11
http://www.d3lexicon.com/affix/ruby DamageReductionFire 12
http://www.d3lexicon.com/affix/damage-reduction-holy-1 DamageReductionHoly 1
http://www.d3lexicon.com/affix/damage-reduction-holy-2 DamageReductionHoly 2
http://www.d3lexicon.com/affix/damage-reduction-holy-3 DamageReductionHoly 3
http://www.d3lexicon.com/affix/damage-reduction-holy-4 DamageReductionHoly 4
http://www.d3lexicon.com/affix/damage-reduction-holy-5 DamageReductionHoly 5
http://www.d3lexicon.com/affix/damage-reduction-holy-6 DamageReductionHoly 6
http://www.d3lexicon.com/affix/damage-reduction-holy-7 DamageReductionHoly 7
http://www.d3lexicon.com/affix/damage-reduction-holy-8 DamageReductionHoly 8
http://www.d3lexicon.com/affix/damage-reduction-holy-9 DamageReductionHoly 9
http://www.d3lexicon.com/affix/damage-reduction-holy-10 DamageReductionHoly 10
http://www.d3lexicon.com/affix/damage-reduction-holy-11 DamageReductionHoly 11
http://www.d3lexicon.com/affix/damage-reduction-holy-12 DamageReductionHoly 12
http://www.d3lexicon.com/affix/citrine DamageReductionLightning 1
http://www.d3lexicon.com/affix/citrine-2 DamageReductionLightning 2
http://www.d3lexicon.com/affix/citrine-3 DamageReductionLightning 3
http://www.d3lexicon.com/affix/citrine-4 DamageReductionLightning 4
http://www.d3lexicon.com/affix/citrine-5 DamageReductionLightning 5
http://www.d3lexicon.com/affix/citrine-6 DamageReductionLightning 6
http://www.d3lexicon.com/affix/citrine-7 DamageReductionLightning 7
http://www.d3lexicon.com/affix/citrine-8 DamageReductionLightning 8
http://www.d3lexicon.com/affix/ocher DamageReductionLightning 9
http://www.d3lexicon.com/affix/ocher-2 DamageReductionLightning 10
http://www.d3lexicon.com/affix/coral DamageReductionLightning 11
http://www.d3lexicon.com/affix/amber DamageReductionLightning 12
http://www.d3lexicon.com/affix/beryl DamageReductionPoison 1
http://www.d3lexicon.com/affix/beryl-2 DamageReductionPoison 2
http://www.d3lexicon.com/affix/beryl-3 DamageReductionPoison 3
http://www.d3lexicon.com/affix/beryl-4 DamageReductionPoison 4
http://www.d3lexicon.com/affix/beryl-5 DamageReductionPoison 5
http://www.d3lexicon.com/affix/beryl-6 DamageReductionPoison 6
http://www.d3lexicon.com/affix/beryl-7 DamageReductionPoison 7
http://www.d3lexicon.com/affix/beryl-8 DamageReductionPoison 8
http://www.d3lexicon.com/affix/viridian DamageReductionPoison 9
http://www.d3lexicon.com/affix/viridian-2 DamageReductionPoison 10
http://www.d3lexicon.com/affix/jade DamageReductionPoison 11
http://www.d3lexicon.com/affix/emerald DamageReductionPoison 12
http://www.d3lexicon.com/affix/savage-2 Damage V
http://www.d3lexicon.com/affix/savage-3 Damage VI
http://www.d3lexicon.com/affix/grim Damage VII
http://www.d3lexicon.com/affix/piercing DamageVsElite 1
http://www.d3lexicon.com/affix/damage-vs-elite-1-secondary DamageVsElite 1 Secondary
http://www.d3lexicon.com/affix/piercing-2 DamageVsElite 2
http://www.d3lexicon.com/affix/damage-vs-elite-2-secondary DamageVsElite 2 Secondary
http://www.d3lexicon.com/affix/piercing-3 DamageVsElite 3
http://www.d3lexicon.com/affix/damage-vs-elite-3-secondary DamageVsElite 3 Secondary
http://www.d3lexicon.com/affix/damage-vs-monster-type-beast-01-legendary DamageVsMonsterTypeBeast 0.1 Legendary
http://www.d3lexicon.com/affix/of-the-hunter DamageVsMonsterTypeBeast 1
http://www.d3lexicon.com/affix/of-the-hunter-2 DamageVsMonsterTypeBeast 2
http://www.d3lexicon.com/affix/of-the-hunter-3 DamageVsMonsterTypeBeast 3
http://www.d3lexicon.com/affix/of-the-hunter-4 DamageVsMonsterTypeBeast 4
http://www.d3lexicon.com/affix/of-the-hunter-5 DamageVsMonsterTypeBeast 5
http://www.d3lexicon.com/affix/of-the-hunter-6 DamageVsMonsterTypeBeast 6
http://www.d3lexicon.com/affix/of-the-hunter-7 DamageVsMonsterTypeBeast 7
http://www.d3lexicon.com/affix/damage-vs-monster-type-demon-01-legendary DamageVsMonsterTypeDemon 0.1 Legendary
http://www.d3lexicon.com/affix/of-demon-slaying DamageVsMonsterTypeDemon 1
http://www.d3lexicon.com/affix/of-demon-slaying-2 DamageVsMonsterTypeDemon 2
http://www.d3lexicon.com/affix/of-demon-slaying-3 DamageVsMonsterTypeDemon 3
http://www.d3lexicon.com/affix/of-demon-slaying-4 DamageVsMonsterTypeDemon 4
http://www.d3lexicon.com/affix/of-demon-slaying-5 DamageVsMonsterTypeDemon 5
http://www.d3lexicon.com/affix/of-demon-slaying-6 DamageVsMonsterTypeDemon 6
http://www.d3lexicon.com/affix/of-demon-slaying-7 DamageVsMonsterTypeDemon 7
http://www.d3lexicon.com/affix/damage-vs-monster-type-human-01-legendary DamageVsMonsterTypeHuman 0.1 Legendary
http://www.d3lexicon.com/affix/of-mortality DamageVsMonsterTypeHuman 1
http://www.d3lexicon.com/affix/of-mortality-2 DamageVsMonsterTypeHuman 2
http://www.d3lexicon.com/affix/of-mortality-3 DamageVsMonsterTypeHuman 3
http://www.d3lexicon.com/affix/of-mortality-4 DamageVsMonsterTypeHuman 4
http://www.d3lexicon.com/affix/of-mortality-5 DamageVsMonsterTypeHuman 5
http://www.d3lexicon.com/affix/of-mortality-6 DamageVsMonsterTypeHuman 6
http://www.d3lexicon.com/affix/of-mortality-7 DamageVsMonsterTypeHuman 7
http://www.d3lexicon.com/affix/damage-vs-monster-type-undead-01-legendary DamageVsMonsterTypeUndead 0.1 Legendary
http://www.d3lexicon.com/affix/of-purification DamageVsMonsterTypeUndead 1
http://www.d3lexicon.com/affix/of-purification-2 DamageVsMonsterTypeUndead 2
http://www.d3lexicon.com/affix/of-purification-3 DamageVsMonsterTypeUndead 3
http://www.d3lexicon.com/affix/of-purification-4 DamageVsMonsterTypeUndead 4
http://www.d3lexicon.com/affix/of-purification-5 DamageVsMonsterTypeUndead 5
http://www.d3lexicon.com/affix/of-purification-6 DamageVsMonsterTypeUndead 6
http://www.d3lexicon.com/affix/of-purification-7 DamageVsMonsterTypeUndead 7
http://www.d3lexicon.com/affix/dam-conversion-heal-1 DamConversionHeal 1
http://www.d3lexicon.com/affix/dam-conversion-heal-2 DamConversionHeal 2
http://www.d3lexicon.com/affix/dam-conversion-heal-3 DamConversionHeal 3
http://www.d3lexicon.com/affix/dam-conversion-heal-4 DamConversionHeal 4
http://www.d3lexicon.com/affix/dam-conversion-heal-5 DamConversionHeal 5
http://www.d3lexicon.com/affix/dam-conversion-heal-6 DamConversionHeal 6
http://www.d3lexicon.com/affix/dam-conversion-heal-7 DamConversionHeal 7
http://www.d3lexicon.com/affix/dam-conversion-heal-8 DamConversionHeal 8
http://www.d3lexicon.com/affix/dam-conversion-heal-9 DamConversionHeal 9
http://www.d3lexicon.com/affix/dam-conversion-heal-10 DamConversionHeal 10
http://www.d3lexicon.com/affix/dam-conversion-heal-11 DamConversionHeal 11
http://www.d3lexicon.com/affix/dam-conversion-heal-12 DamConversionHeal 12
http://www.d3lexicon.com/affix/resolute DamReductionVsElite 1
http://www.d3lexicon.com/affix/resolute-2 DamReductionVsElite 2
http://www.d3lexicon.com/affix/resolute-3 DamReductionVsElite 3
http://www.d3lexicon.com/affix/decoy-i Decoy I
http://www.d3lexicon.com/affix/intercepting Defense I
http://www.d3lexicon.com/affix/intercepting-2 Defense II
http://www.d3lexicon.com/affix/vigilant Defense III
http://www.d3lexicon.com/affix/vigilant-2 Defense IV
http://www.d3lexicon.com/affix/of-the-gladiator DefenseMelee 1
http://www.d3lexicon.com/affix/of-the-gladiator-2 DefenseMelee 2
http://www.d3lexicon.com/affix/of-the-gladiator-3 DefenseMelee 3
http://www.d3lexicon.com/affix/of-the-gladiator-4 DefenseMelee 4
http://www.d3lexicon.com/affix/deflecting DefenseMissile 1
http://www.d3lexicon.com/affix/deflecting-2 DefenseMissile 2
http://www.d3lexicon.com/affix/deflecting-3 DefenseMissile 3
http://www.d3lexicon.com/affix/deflecting-4 DefenseMissile 4
http://www.d3lexicon.com/affix/sentinel Defense V
http://www.d3lexicon.com/affix/sentinel-2 Defense VI
http://www.d3lexicon.com/affix/bastion Defense VII
http://www.d3lexicon.com/affix/of-the-hawk Dex 1
http://www.d3lexicon.com/affix/dex-1-secondary Dex 1 Secondary
http://www.d3lexicon.com/affix/of-the-hawk-2 Dex 2
http://www.d3lexicon.com/affix/dex-2-secondary Dex 2 Secondary
http://www.d3lexicon.com/affix/of-the-hawk-3 Dex 3
http://www.d3lexicon.com/affix/dex-3-secondary Dex 3 Secondary
http://www.d3lexicon.com/affix/of-the-hawk-4 Dex 4
http://www.d3lexicon.com/affix/dex-4-secondary Dex 4 Secondary
http://www.d3lexicon.com/affix/of-the-hawk-5 Dex 5
http://www.d3lexicon.com/affix/dex-5-secondary Dex 5 Secondary
http://www.d3lexicon.com/affix/of-the-hawk-6 Dex 6
http://www.d3lexicon.com/affix/dex-6-secondary Dex 6 Secondary
http://www.d3lexicon.com/affix/of-cruelty Dex 7
http://www.d3lexicon.com/affix/dex-7-secondary Dex 7 Secondary
http://www.d3lexicon.com/affix/of-cruelty-2 Dex 8
http://www.d3lexicon.com/affix/dex-8-secondary Dex 8 Secondary
http://www.d3lexicon.com/affix/of-cruelty-3 Dex 9
http://www.d3lexicon.com/affix/dex-9-secondary Dex 9 Secondary
http://www.d3lexicon.com/affix/of-cruelty-4 Dex 10
http://www.d3lexicon.com/affix/dex-10-secondary Dex 10 Secondary
http://www.d3lexicon.com/affix/of-cruelty-5 Dex 11
http://www.d3lexicon.com/affix/dex-11-secondary Dex 11 Secondary
http://www.d3lexicon.com/affix/of-pain Dex 12
http://www.d3lexicon.com/affix/dex-12-secondary Dex 12 Secondary
http://www.d3lexicon.com/affix/of-pain-2 Dex 13
http://www.d3lexicon.com/affix/dex-13-secondary Dex 13 Secondary
http://www.d3lexicon.com/affix/of-pain-3 Dex 14
http://www.d3lexicon.com/affix/dex-14-secondary Dex 14 Secondary
http://www.d3lexicon.com/affix/of-pain-4 Dex 15
http://www.d3lexicon.com/affix/dex-15-secondary Dex 15 Secondary
http://www.d3lexicon.com/affix/of-pain-5 Dex 16
http://www.d3lexicon.com/affix/dex-16-secondary Dex 16 Secondary
http://www.d3lexicon.com/affix/true DexInt I
http://www.d3lexicon.com/affix/true-2 DexInt II
http://www.d3lexicon.com/affix/true-3 DexInt III
http://www.d3lexicon.com/affix/dex-int-iii-secondary DexInt III Secondary
http://www.d3lexicon.com/affix/dex-int-ii-secondary DexInt II Secondary
http://www.d3lexicon.com/affix/dex-int-i-secondary DexInt I Secondary
http://www.d3lexicon.com/affix/true-4 DexInt IV
http://www.d3lexicon.com/affix/dex-int-iv-secondary DexInt IV Secondary
http://www.d3lexicon.com/affix/worthy DexInt IX
http://www.d3lexicon.com/affix/dex-int-ix-secondary DexInt IX Secondary
http://www.d3lexicon.com/affix/steadfast DexInt V
http://www.d3lexicon.com/affix/steadfast-2 DexInt VI
http://www.d3lexicon.com/affix/steadfast-3 DexInt VII
http://www.d3lexicon.com/affix/steadfast-4 DexInt VIII
http://www.d3lexicon.com/affix/dex-int-viii-secondary DexInt VIII Secondary
http://www.d3lexicon.com/affix/dex-int-vii-secondary DexInt VII Secondary
http://www.d3lexicon.com/affix/dex-int-vi-secondary DexInt VI Secondary
http://www.d3lexicon.com/affix/dex-int-v-secondary DexInt V Secondary
http://www.d3lexicon.com/affix/worthy-2 DexInt X
http://www.d3lexicon.com/affix/worthy-3 DexInt XI
http://www.d3lexicon.com/affix/marvelous DexInt XII
http://www.d3lexicon.com/affix/dex-int-xii-secondary DexInt XII Secondary
http://www.d3lexicon.com/affix/dex-int-xi-secondary DexInt XI Secondary
http://www.d3lexicon.com/affix/dex-int-x-secondary DexInt X Secondary
http://www.d3lexicon.com/affix/feral DexVit I
http://www.d3lexicon.com/affix/feral-2 DexVit II
http://www.d3lexicon.com/affix/feral-3 DexVit III
http://www.d3lexicon.com/affix/dex-vit-iii-secondary DexVit III Secondary
http://www.d3lexicon.com/affix/dex-vit-ii-secondary DexVit II Secondary
http://www.d3lexicon.com/affix/dex-vit-i-secondary DexVit I Secondary
http://www.d3lexicon.com/affix/feral-4 DexVit IV
http://www.d3lexicon.com/affix/dex-vit-iv-secondary DexVit IV Secondary
http://www.d3lexicon.com/affix/potent DexVit IX
http://www.d3lexicon.com/affix/dex-vit-ix-secondary DexVit IX Secondary
http://www.d3lexicon.com/affix/wild DexVit V
http://www.d3lexicon.com/affix/wild-2 DexVit VI
http://www.d3lexicon.com/affix/wild-3 DexVit VII
http://www.d3lexicon.com/affix/wild-4 DexVit VIII
http://www.d3lexicon.com/affix/dex-vit-viii-secondary DexVit VIII Secondary
http://www.d3lexicon.com/affix/dex-vit-vii-secondary DexVit VII Secondary
http://www.d3lexicon.com/affix/dex-vit-vi-secondary DexVit VI Secondary
http://www.d3lexicon.com/affix/dex-vit-v-secondary DexVit V Secondary
http://www.d3lexicon.com/affix/potent-2 DexVit X
http://www.d3lexicon.com/affix/potent-3 DexVit XI
http://www.d3lexicon.com/affix/valiant DexVit XII
http://www.d3lexicon.com/affix/dex-vit-xii-secondary DexVit XII Secondary
http://www.d3lexicon.com/affix/dex-vit-xi-secondary DexVit XI Secondary
http://www.d3lexicon.com/affix/dex-vit-x-secondary DexVit X Secondary
http://www.d3lexicon.com/affix/dirty-fighting-i Dirty Fighting I
http://www.d3lexicon.com/affix/disorient-i Disorient I
http://www.d3lexicon.com/affix/of-the-tower DR 1
http://www.d3lexicon.com/affix/dr-1-secondary DR 1 Secondary
http://www.d3lexicon.com/affix/of-the-tower-2 DR 2
http://www.d3lexicon.com/affix/dr-2-secondary DR 2 Secondary
http://www.d3lexicon.com/affix/of-the-tower-3 DR 3
http://www.d3lexicon.com/affix/dr-3-secondary DR 3 Secondary
http://www.d3lexicon.com/affix/of-the-tower-4 DR 4
http://www.d3lexicon.com/affix/dr-4-secondary DR 4 Secondary
http://www.d3lexicon.com/affix/of-the-tower-5 DR 5
http://www.d3lexicon.com/affix/dr-5-secondary DR 5 Secondary
http://www.d3lexicon.com/affix/of-the-tower-6 DR 6
http://www.d3lexicon.com/affix/dr-6-secondary DR 6 Secondary
http://www.d3lexicon.com/affix/of-the-stronghold DR 7
http://www.d3lexicon.com/affix/dr-7-secondary DR 7 Secondary
http://www.d3lexicon.com/affix/of-the-stronghold-2 DR 8
http://www.d3lexicon.com/affix/dr-8-secondary DR 8 Secondary
http://www.d3lexicon.com/affix/of-the-stronghold-3 DR 9
http://www.d3lexicon.com/affix/dr-9-secondary DR 9 Secondary
http://www.d3lexicon.com/affix/of-the-stronghold-4 DR 10
http://www.d3lexicon.com/affix/dr-10-secondary DR 10 Secondary
http://www.d3lexicon.com/affix/of-the-stronghold-5 DR 11
http://www.d3lexicon.com/affix/dr-11-secondary DR 11 Secondary
http://www.d3lexicon.com/affix/of-the-stronghold-6 DR 12
http://www.d3lexicon.com/affix/dr-12-secondary DR 12 Secondary
http://www.d3lexicon.com/affix/of-the-fortress DR 13
http://www.d3lexicon.com/affix/dr-13-secondary DR 13 Secondary
http://www.d3lexicon.com/affix/of-the-fortress-2 DR 14
http://www.d3lexicon.com/affix/dr-14-secondary DR 14 Secondary
http://www.d3lexicon.com/affix/of-the-fortress-3 DR 15
http://www.d3lexicon.com/affix/dr-15-secondary DR 15 Secondary
http://www.d3lexicon.com/affix/of-the-fortress-4 DR 16
http://www.d3lexicon.com/affix/dr-16-secondary DR 16 Secondary
http://www.d3lexicon.com/affix/of-the-fortress-5 DR 17
http://www.d3lexicon.com/affix/dr-17-secondary DR 17 Secondary
http://www.d3lexicon.com/affix/of-the-fortress-6 DR 18
http://www.d3lexicon.com/affix/dr-18-secondary DR 18 Secondary
http://www.d3lexicon.com/affix/of-the-castle DR 19
http://www.d3lexicon.com/affix/dr-19-secondary DR 19 Secondary
http://www.d3lexicon.com/affix/empathy-i Empathy I
http://www.d3lexicon.com/affix/energize-i Energize I
http://www.d3lexicon.com/affix/energy-bomb-i Energy Bomb I
http://www.d3lexicon.com/affix/adventuring Experience I
http://www.d3lexicon.com/affix/adventuring-2 Experience II
http://www.d3lexicon.com/affix/adventuring-3 Experience III
http://www.d3lexicon.com/affix/adventuring-4 Experience IV
http://www.d3lexicon.com/affix/restless Experience IX
http://www.d3lexicon.com/affix/clever Experience V
http://www.d3lexicon.com/affix/clever-2 Experience VI
http://www.d3lexicon.com/affix/clever-3 Experience VII
http://www.d3lexicon.com/affix/clever-4 Experience VIII
http://www.d3lexicon.com/affix/restless-2 Experience X
http://www.d3lexicon.com/affix/restless-3 Experience XI
http://www.d3lexicon.com/affix/savvy Experience XII
http://www.d3lexicon.com/affix/of-flame FireD 1
http://www.d3lexicon.com/affix/fire-damage-1-fast FireD 1 Fast
http://www.d3lexicon.com/affix/of-flame-2 FireD 2
http://www.d3lexicon.com/affix/fire-damage-2-fast FireD 2 Fast
http://www.d3lexicon.com/affix/of-flame-3 FireD 3
http://www.d3lexicon.com/affix/fire-damage-3-fast FireD 3 Fast
http://www.d3lexicon.com/affix/of-flame-4 FireD 4
http://www.d3lexicon.com/affix/fire-damage-4-fast FireD 4 Fast
http://www.d3lexicon.com/affix/of-flame-5 FireD 5
http://www.d3lexicon.com/affix/fire-damage-5-fast FireD 5 Fast
http://www.d3lexicon.com/affix/of-immolation FireD 6
http://www.d3lexicon.com/affix/fire-damage-6-fast FireD 6 Fast
http://www.d3lexicon.com/affix/of-immolation-2 FireD 7
http://www.d3lexicon.com/affix/fire-damage-7-fast FireD 7 Fast
http://www.d3lexicon.com/affix/of-immolation-3 FireD 8
http://www.d3lexicon.com/affix/fire-damage-8-fast FireD 8 Fast
http://www.d3lexicon.com/affix/of-immolation-4 FireD 9
http://www.d3lexicon.com/affix/fire-damage-9-fast FireD 9 Fast
http://www.d3lexicon.com/affix/of-burning FireD 10
http://www.d3lexicon.com/affix/fire-damage-10-fast FireD 10 Fast
http://www.d3lexicon.com/affix/of-burning-2 FireD 11
http://www.d3lexicon.com/affix/fire-damage-11-fast FireD 11 Fast
http://www.d3lexicon.com/affix/of-burning-3 FireD 12
http://www.d3lexicon.com/affix/fire-damage-12-fast FireD 12 Fast
http://www.d3lexicon.com/affix/of-burning-4 FireD 13
http://www.d3lexicon.com/affix/fire-damage-13-fast FireD 13 Fast
http://www.d3lexicon.com/affix/of-incineration FireD 14
http://www.d3lexicon.com/affix/fire-damage-14-fast FireD 14 Fast
http://www.d3lexicon.com/affix/fire-resist-01-legendary FireResist 0.1 Legendary
http://www.d3lexicon.com/affix/fire-resist-02-legendary FireResist 0.2 Legendary
http://www.d3lexicon.com/affix/fire-resist-03-legendary FireResist 0.3 Legendary
http://www.d3lexicon.com/affix/seared FireResist I
http://www.d3lexicon.com/affix/seared-2 FireResist II
http://www.d3lexicon.com/affix/seared-3 FireResist III
http://www.d3lexicon.com/affix/seared-4 FireResist IV
http://www.d3lexicon.com/affix/scorched FireResist IX
http://www.d3lexicon.com/affix/charred FireResist V
http://www.d3lexicon.com/affix/charred-2 FireResist VI
http://www.d3lexicon.com/affix/charred-3 FireResist VII
http://www.d3lexicon.com/affix/charred-4 FireResist VIII
http://www.d3lexicon.com/affix/scorched-2 FireResist X
http://www.d3lexicon.com/affix/scorched-3 FireResist XI
http://www.d3lexicon.com/affix/infernal FireResist XII
http://www.d3lexicon.com/affix/focused-mind-i Focused Mind I
http://www.d3lexicon.com/affix/forceful-push-i Forceful Push I
http://www.d3lexicon.com/affix/barbaric FuryHeals 1
http://www.d3lexicon.com/affix/barbaric-2 FuryHeals 2
http://www.d3lexicon.com/affix/barbaric-3 FuryHeals 3
http://www.d3lexicon.com/affix/wanton FuryHeals 4
http://www.d3lexicon.com/affix/wanton-2 FuryHeals 5
http://www.d3lexicon.com/affix/wanton-3 FuryHeals 6
http://www.d3lexicon.com/affix/infuriating FuryHeals 7
http://www.d3lexicon.com/affix/infuriating-2 FuryHeals 8
http://www.d3lexicon.com/affix/infuriating-3 FuryHeals 9
http://www.d3lexicon.com/affix/vindictive FuryHeals 10
http://www.d3lexicon.com/affix/of-fury FurySetPoint I
http://www.d3lexicon.com/affix/lucky Gold I
http://www.d3lexicon.com/affix/lucky-2 Gold II
http://www.d3lexicon.com/affix/lucky-3 Gold III
http://www.d3lexicon.com/affix/gold-iii-secondary Gold III Secondary
http://www.d3lexicon.com/affix/gold-ii-secondary Gold II Secondary
http://www.d3lexicon.com/affix/gold-i-secondary Gold I Secondary
http://www.d3lexicon.com/affix/glittering Gold IV
http://www.d3lexicon.com/affix/gold-iv-secondary Gold IV Secondary
http://www.d3lexicon.com/affix/gathering GoldPickUpRadius 1
http://www.d3lexicon.com/affix/gathering-2 GoldPickUpRadius 2
http://www.d3lexicon.com/affix/greedy GoldPickUpRadius 3
http://www.d3lexicon.com/affix/greedy-2 GoldPickUpRadius 4
http://www.d3lexicon.com/affix/miserly GoldPickUpRadius 5
http://www.d3lexicon.com/affix/avaricious GoldPickUpRadius 6
http://www.d3lexicon.com/affix/glittering-2 Gold V
http://www.d3lexicon.com/affix/glittering-3 Gold VI
http://www.d3lexicon.com/affix/prosperous Gold VII
http://www.d3lexicon.com/affix/prosperous-2 Gold VIII
http://www.d3lexicon.com/affix/gold-viii-secondary Gold VIII Secondary
http://www.d3lexicon.com/affix/gold-vii-secondary Gold VII Secondary
http://www.d3lexicon.com/affix/gold-vi-secondary Gold VI Secondary
http://www.d3lexicon.com/affix/gold-v-secondary Gold V Secondary
http://www.d3lexicon.com/affix/guardian-i Guardian I
http://www.d3lexicon.com/affix/guidance-i Guidance I
http://www.d3lexicon.com/affix/keen Haste 1
http://www.d3lexicon.com/affix/haste-1-secondary Haste 1 Secondary
http://www.d3lexicon.com/affix/keen-2 Haste 2
http://www.d3lexicon.com/affix/haste-2-secondary Haste 2 Secondary
http://www.d3lexicon.com/affix/keen-3 Haste 3
http://www.d3lexicon.com/affix/haste-3-secondary Haste 3 Secondary
http://www.d3lexicon.com/affix/raiding Haste 4
http://www.d3lexicon.com/affix/haste-4-secondary Haste 4 Secondary
http://www.d3lexicon.com/affix/raiding-2 Haste 5
http://www.d3lexicon.com/affix/haste-5-secondary Haste 5 Secondary
http://www.d3lexicon.com/affix/raiding-3 Haste 6
http://www.d3lexicon.com/affix/haste-6-secondary Haste 6 Secondary
http://www.d3lexicon.com/affix/assailing Haste 7
http://www.d3lexicon.com/affix/haste-7-secondary Haste 7 Secondary
http://www.d3lexicon.com/affix/assailing-2 Haste 8
http://www.d3lexicon.com/affix/haste-8-secondary Haste 8 Secondary
http://www.d3lexicon.com/affix/assailing-3 Haste 9
http://www.d3lexicon.com/affix/vanquishing Haste 10
http://www.d3lexicon.com/affix/spiteful HatredRegen 1
http://www.d3lexicon.com/affix/spiteful-2 HatredRegen 2
http://www.d3lexicon.com/affix/spiteful-3 HatredRegen 3
http://www.d3lexicon.com/affix/bitter HatredRegen 4
http://www.d3lexicon.com/affix/bitter-2 HatredRegen 5
http://www.d3lexicon.com/affix/bitter-3 HatredRegen 6
http://www.d3lexicon.com/affix/hostile HatredRegen 7
http://www.d3lexicon.com/affix/hostile-2 HatredRegen 8
http://www.d3lexicon.com/affix/hostile-3 HatredRegen 9
http://www.d3lexicon.com/affix/vengeful HatredRegen 10
http://www.d3lexicon.com/affix/heal-i Heal I
http://www.d3lexicon.com/affix/mending HealthGlobeBonus 1
http://www.d3lexicon.com/affix/mending-2 HealthGlobeBonus 2
http://www.d3lexicon.com/affix/mending-3 HealthGlobeBonus 3
http://www.d3lexicon.com/affix/mending-4 HealthGlobeBonus 4
http://www.d3lexicon.com/affix/invigorating HealthGlobeBonus 5
http://www.d3lexicon.com/affix/invigorating-2 HealthGlobeBonus 6
http://www.d3lexicon.com/affix/invigorating-3 HealthGlobeBonus 7
http://www.d3lexicon.com/affix/invigorating-4 HealthGlobeBonus 8
http://www.d3lexicon.com/affix/renewing HealthGlobeBonus 9
http://www.d3lexicon.com/affix/renewing-2 HealthGlobeBonus 10
http://www.d3lexicon.com/affix/renewing-3 HealthGlobeBonus 11
http://www.d3lexicon.com/affix/euphoric HealthGlobeBonus 12
http://www.d3lexicon.com/affix/health-globe-chance-i HealthGlobeChance I
http://www.d3lexicon.com/affix/dazzling HitBlind 1
http://www.d3lexicon.com/affix/dazzling-2 HitBlind 2
http://www.d3lexicon.com/affix/dazzling-3 HitBlind 3
http://www.d3lexicon.com/affix/dazzling-4 HitBlind 4
http://www.d3lexicon.com/affix/bewildering HitBlind 5
http://www.d3lexicon.com/affix/bewildering-2 HitBlind 6
http://www.d3lexicon.com/affix/bewildering-3 HitBlind 7
http://www.d3lexicon.com/affix/bewildering-4 HitBlind 8
http://www.d3lexicon.com/affix/perplexing HitBlind 9
http://www.d3lexicon.com/affix/perplexing-2 HitBlind 10
http://www.d3lexicon.com/affix/perplexing-3 HitBlind 11
http://www.d3lexicon.com/affix/hypnotic HitBlind 12
http://www.d3lexicon.com/affix/chilling HitChill 1
http://www.d3lexicon.com/affix/chilling-2 HitChill 2
http://www.d3lexicon.com/affix/chilling-3 HitChill 3
http://www.d3lexicon.com/affix/chilling-4 HitChill 4
http://www.d3lexicon.com/affix/bleak HitChill 5
http://www.d3lexicon.com/affix/bleak-2 HitChill 6
http://www.d3lexicon.com/affix/bleak-3 HitChill 7
http://www.d3lexicon.com/affix/bleak-4 HitChill 8
http://www.d3lexicon.com/affix/glacial HitChill 9
http://www.d3lexicon.com/affix/glacial-2 HitChill 10
http://www.d3lexicon.com/affix/glacial-3 HitChill 11
http://www.d3lexicon.com/affix/hyperborean HitChill 12
http://www.d3lexicon.com/affix/of-fright HitFear 1
http://www.d3lexicon.com/affix/of-fright-2 HitFear 2
http://www.d3lexicon.com/affix/of-fright-3 HitFear 3
http://www.d3lexicon.com/affix/of-fright-4 HitFear 4
http://www.d3lexicon.com/affix/of-nightmares HitFear 5
http://www.d3lexicon.com/affix/of-nightmares-2 HitFear 6
http://www.d3lexicon.com/affix/of-nightmares-3 HitFear 7
http://www.d3lexicon.com/affix/of-nightmares-4 HitFear 8
http://www.d3lexicon.com/affix/of-horror HitFear 9
http://www.d3lexicon.com/affix/of-horror-2 HitFear 10
http://www.d3lexicon.com/affix/of-horror-3 HitFear 11
http://www.d3lexicon.com/affix/of-terror HitFear 12
http://www.d3lexicon.com/affix/of-ice HitFreeze 1
http://www.d3lexicon.com/affix/of-ice-2 HitFreeze 2
http://www.d3lexicon.com/affix/of-ice-3 HitFreeze 3
http://www.d3lexicon.com/affix/of-ice-4 HitFreeze 4
http://www.d3lexicon.com/affix/of-hail HitFreeze 5
http://www.d3lexicon.com/affix/of-hail-2 HitFreeze 6
http://www.d3lexicon.com/affix/of-hail-3 HitFreeze 7
http://www.d3lexicon.com/affix/of-hail-4 HitFreeze 8
http://www.d3lexicon.com/affix/of-the-frozen-sea HitFreeze 9
http://www.d3lexicon.com/affix/of-the-frozen-sea-2 HitFreeze 10
http://www.d3lexicon.com/affix/of-the-frozen-sea-3 HitFreeze 11
http://www.d3lexicon.com/affix/of-desolation HitFreeze 12
http://www.d3lexicon.com/affix/of-stagnation HitImmobilize 1
http://www.d3lexicon.com/affix/of-stagnation-2 HitImmobilize 2
http://www.d3lexicon.com/affix/of-stagnation-3 HitImmobilize 3
http://www.d3lexicon.com/affix/of-stagnation-4 HitImmobilize 4
http://www.d3lexicon.com/affix/of-impairment HitImmobilize 5
http://www.d3lexicon.com/affix/of-impairment-2 HitImmobilize 6
http://www.d3lexicon.com/affix/of-impairment-3 HitImmobilize 7
http://www.d3lexicon.com/affix/of-impairment-4 HitImmobilize 8
http://www.d3lexicon.com/affix/of-sabotage HitImmobilize 9
http://www.d3lexicon.com/affix/of-sabotage-2 HitImmobilize 10
http://www.d3lexicon.com/affix/of-sabotage-3 HitImmobilize 11
http://www.d3lexicon.com/affix/of-paralysis HitImmobilize 12
http://www.d3lexicon.com/affix/battering HitKnockback 1
http://www.d3lexicon.com/affix/battering-2 HitKnockback 2
http://www.d3lexicon.com/affix/battering-3 HitKnockback 3
http://www.d3lexicon.com/affix/battering-4 HitKnockback 4
http://www.d3lexicon.com/affix/pummeling HitKnockback 5
http://www.d3lexicon.com/affix/pummeling-2 HitKnockback 6
http://www.d3lexicon.com/affix/pummeling-3 HitKnockback 7
http://www.d3lexicon.com/affix/pummeling-4 HitKnockback 8
http://www.d3lexicon.com/affix/smashing HitKnockback 9
http://www.d3lexicon.com/affix/smashing-2 HitKnockback 10
http://www.d3lexicon.com/affix/smashing-3 HitKnockback 11
http://www.d3lexicon.com/affix/pulverizing HitKnockback 12
http://www.d3lexicon.com/affix/of-the-leech HitLife 1
http://www.d3lexicon.com/affix/hit-life-1-secondary HitLife 1 Secondary
http://www.d3lexicon.com/affix/of-the-leech-2 HitLife 2
http://www.d3lexicon.com/affix/hit-life-2-secondary HitLife 2 Secondary
http://www.d3lexicon.com/affix/of-the-leech-3 HitLife 3
http://www.d3lexicon.com/affix/hit-life-3-secondary HitLife 3 Secondary
http://www.d3lexicon.com/affix/of-the-leech-4 HitLife 4
http://www.d3lexicon.com/affix/hit-life-4-secondary HitLife 4 Secondary
http://www.d3lexicon.com/affix/of-carnage HitLife 5
http://www.d3lexicon.com/affix/hit-life-5-secondary HitLife 5 Secondary
http://www.d3lexicon.com/affix/of-carnage-2 HitLife 6
http://www.d3lexicon.com/affix/hit-life-6-secondary HitLife 6 Secondary
http://www.d3lexicon.com/affix/of-carnage-3 HitLife 7
http://www.d3lexicon.com/affix/hit-life-7-secondary HitLife 7 Secondary
http://www.d3lexicon.com/affix/of-carnage-4 HitLife 8
http://www.d3lexicon.com/affix/hit-life-8-secondary HitLife 8 Secondary
http://www.d3lexicon.com/affix/of-carnage-5 HitLife 9
http://www.d3lexicon.com/affix/hit-life-9-secondary HitLife 9 Secondary
http://www.d3lexicon.com/affix/of-gore HitLife 10
http://www.d3lexicon.com/affix/hit-life-10-secondary HitLife 10 Secondary
http://www.d3lexicon.com/affix/of-gore-2 HitLife 11
http://www.d3lexicon.com/affix/hit-life-11-secondary HitLife 11 Secondary
http://www.d3lexicon.com/affix/of-gore-3 HitLife 12
http://www.d3lexicon.com/affix/hit-life-12-secondary HitLife 12 Secondary
http://www.d3lexicon.com/affix/of-gore-4 HitLife 13
http://www.d3lexicon.com/affix/hit-life-13-secondary HitLife 13 Secondary
http://www.d3lexicon.com/affix/of-mangling HitLife 14
http://www.d3lexicon.com/affix/hit-life-14-secondary HitLife 14 Secondary
http://www.d3lexicon.com/affix/of-the-bat HitMana 1
http://www.d3lexicon.com/affix/of-the-bat-2 HitMana 2
http://www.d3lexicon.com/affix/of-the-bat-3 HitMana 3
http://www.d3lexicon.com/affix/of-the-bat-4 HitMana 4
http://www.d3lexicon.com/affix/of-craving HitMana 5
http://www.d3lexicon.com/affix/of-craving-2 HitMana 6
http://www.d3lexicon.com/affix/of-craving-3 HitMana 7
http://www.d3lexicon.com/affix/of-craving-4 HitMana 8
http://www.d3lexicon.com/affix/of-draining HitMana 9
http://www.d3lexicon.com/affix/of-draining-2 HitMana 10
http://www.d3lexicon.com/affix/of-draining-3 HitMana 11
http://www.d3lexicon.com/affix/of-devouring HitMana 12
http://www.d3lexicon.com/affix/crippling HitSlow 1
http://www.d3lexicon.com/affix/crippling-2 HitSlow 2
http://www.d3lexicon.com/affix/crippling-3 HitSlow 3
http://www.d3lexicon.com/affix/crippling-4 HitSlow 4
http://www.d3lexicon.com/affix/punishing HitSlow 5
http://www.d3lexicon.com/affix/punishing-2 HitSlow 6
http://www.d3lexicon.com/affix/punishing-3 HitSlow 7
http://www.d3lexicon.com/affix/punishing-4 HitSlow 8
http://www.d3lexicon.com/affix/persecuting HitSlow 9
http://www.d3lexicon.com/affix/persecuting-2 HitSlow 10
http://www.d3lexicon.com/affix/persecuting-3 HitSlow 11
http://www.d3lexicon.com/affix/dominating HitSlow 12
http://www.d3lexicon.com/affix/of-striking HitStun 1
http://www.d3lexicon.com/affix/of-striking-2 HitStun 2
http://www.d3lexicon.com/affix/of-striking-3 HitStun 3
http://www.d3lexicon.com/affix/of-striking-4 HitStun 4
http://www.d3lexicon.com/affix/of-bane HitStun 5
http://www.d3lexicon.com/affix/of-bane-2 HitStun 6
http://www.d3lexicon.com/affix/of-bane-3 HitStun 7
http://www.d3lexicon.com/affix/of-bane-4 HitStun 8
http://www.d3lexicon.com/affix/of-ruin HitStun 9
http://www.d3lexicon.com/affix/of-ruin-2 HitStun 10
http://www.d3lexicon.com/affix/of-ruin-3 HitStun 11
http://www.d3lexicon.com/affix/of-devastation-2 HitStun 12
http://www.d3lexicon.com/affix/of-the-angels HolyD 1
http://www.d3lexicon.com/affix/holy-damage-1-fast HolyD 1 Fast
http://www.d3lexicon.com/affix/of-the-angels-2 HolyD 2
http://www.d3lexicon.com/affix/holy-damage-2-fast HolyD 2 Fast
http://www.d3lexicon.com/affix/of-the-angels-3 HolyD 3
http://www.d3lexicon.com/affix/holy-damage-3-fast HolyD 3 Fast
http://www.d3lexicon.com/affix/of-the-angels-4 HolyD 4
http://www.d3lexicon.com/affix/holy-damage-4-fast HolyD 4 Fast
http://www.d3lexicon.com/affix/of-the-angels-5 HolyD 5
http://www.d3lexicon.com/affix/holy-damage-5-fast HolyD 5 Fast
http://www.d3lexicon.com/affix/of-grace HolyD 6
http://www.d3lexicon.com/affix/holy-damage-6-fast HolyD 6 Fast
http://www.d3lexicon.com/affix/of-grace-2 HolyD 7
http://www.d3lexicon.com/affix/holy-damage-7-fast HolyD 7 Fast
http://www.d3lexicon.com/affix/of-grace-3 HolyD 8
http://www.d3lexicon.com/affix/holy-damage-8-fast HolyD 8 Fast
http://www.d3lexicon.com/affix/of-grace-4 HolyD 9
http://www.d3lexicon.com/affix/holy-damage-9-fast HolyD 9 Fast
http://www.d3lexicon.com/affix/of-smiting HolyD 10
http://www.d3lexicon.com/affix/holy-damage-10-fast HolyD 10 Fast
http://www.d3lexicon.com/affix/of-smiting-2 HolyD 11
http://www.d3lexicon.com/affix/holy-damage-11-fast HolyD 11 Fast
http://www.d3lexicon.com/affix/of-smiting-3 HolyD 12
http://www.d3lexicon.com/affix/holy-damage-12-fast HolyD 12 Fast
http://www.d3lexicon.com/affix/of-smiting-4 HolyD 13
http://www.d3lexicon.com/affix/holy-damage-13-fast HolyD 13 Fast
http://www.d3lexicon.com/affix/of-the-heavens HolyD 14
http://www.d3lexicon.com/affix/holy-damage-14-fast HolyD 14 Fast
http://www.d3lexicon.com/affix/indestructible Indestructible 1
http://www.d3lexicon.com/affix/indestructible-2 Indestructible 2
http://www.d3lexicon.com/affix/indestructible-3 Indestructible 3
http://www.d3lexicon.com/affix/indestructible-4 Indestructible 4
http://www.d3lexicon.com/affix/indestructible-5 Indestructible 5
http://www.d3lexicon.com/affix/indestructible-6 Indestructible 6
http://www.d3lexicon.com/affix/indestructible-7 Indestructible 7
http://www.d3lexicon.com/affix/indestructible-8 Indestructible 8
http://www.d3lexicon.com/affix/indestructible-9 Indestructible 9
http://www.d3lexicon.com/affix/indestructible-10 Indestructible 10
http://www.d3lexicon.com/affix/indestructible-11 Indestructible 11
http://www.d3lexicon.com/affix/indestructible-12 Indestructible 12
http://www.d3lexicon.com/affix/low-quality-2 Inferior Armor Def 0
http://www.d3lexicon.com/affix/cracked-2 Inferior Armor Def 1
http://www.d3lexicon.com/affix/crude-2 Inferior Armor Def 2
http://www.d3lexicon.com/affix/damaged-2 Inferior Armor Def 3
http://www.d3lexicon.com/affix/low-quality Inferior Weapon Dam 0
http://www.d3lexicon.com/affix/cracked Inferior Weapon Dam 1
http://www.d3lexicon.com/affix/crude Inferior Weapon Dam 2
http://www.d3lexicon.com/affix/damaged Inferior Weapon Dam 3
http://www.d3lexicon.com/affix/inspire-i Inspire I
http://www.d3lexicon.com/affix/of-focus Int 1
http://www.d3lexicon.com/affix/int-1-secondary Int 1 Secondary
http://www.d3lexicon.com/affix/of-focus-2 Int 2
http://www.d3lexicon.com/affix/int-2-secondary Int 2 Secondary
http://www.d3lexicon.com/affix/of-focus-3 Int 3
http://www.d3lexicon.com/affix/int-3-secondary Int 3 Secondary
http://www.d3lexicon.com/affix/of-focus-4 Int 4
http://www.d3lexicon.com/affix/int-4-secondary Int 4 Secondary
http://www.d3lexicon.com/affix/of-focus-5 Int 5
http://www.d3lexicon.com/affix/int-5-secondary Int 5 Secondary
http://www.d3lexicon.com/affix/of-focus-6 Int 6
http://www.d3lexicon.com/affix/int-6-secondary Int 6 Secondary
http://www.d3lexicon.com/affix/of-the-mind Int 7
http://www.d3lexicon.com/affix/int-7-secondary Int 7 Secondary
http://www.d3lexicon.com/affix/of-the-mind-2 Int 8
http://www.d3lexicon.com/affix/int-8-secondary Int 8 Secondary
http://www.d3lexicon.com/affix/of-the-mind-3 Int 9
http://www.d3lexicon.com/affix/int-9-secondary Int 9 Secondary
http://www.d3lexicon.com/affix/of-the-mind-4 Int 10
http://www.d3lexicon.com/affix/int-10-secondary Int 10 Secondary
http://www.d3lexicon.com/affix/of-the-mind-5 Int 11
http://www.d3lexicon.com/affix/int-11-secondary Int 11 Secondary
http://www.d3lexicon.com/affix/of-omens Int 12
http://www.d3lexicon.com/affix/int-12-secondary Int 12 Secondary
http://www.d3lexicon.com/affix/of-omens-2 Int 13
http://www.d3lexicon.com/affix/int-13-secondary Int 13 Secondary
http://www.d3lexicon.com/affix/of-omens-3 Int 14
http://www.d3lexicon.com/affix/int-14-secondary Int 14 Secondary
http://www.d3lexicon.com/affix/of-omens-4 Int 15
http://www.d3lexicon.com/affix/int-15-secondary Int 15 Secondary
http://www.d3lexicon.com/affix/of-far-sight Int 16
http://www.d3lexicon.com/affix/int-16-secondary Int 16 Secondary
http://www.d3lexicon.com/affix/intervene-i Intervene I
http://www.d3lexicon.com/affix/intidimidate-i Intidimidate I
http://www.d3lexicon.com/affix/proud IntVit I
http://www.d3lexicon.com/affix/proud-2 IntVit II
http://www.d3lexicon.com/affix/proud-3 IntVit III
http://www.d3lexicon.com/affix/int-vit-iii-secondary IntVit III Secondary
http://www.d3lexicon.com/affix/int-vit-ii-secondary IntVit II Secondary
http://www.d3lexicon.com/affix/int-vit-i-secondary IntVit I Secondary
http://www.d3lexicon.com/affix/proud-4 IntVit IV
http://www.d3lexicon.com/affix/int-vit-iv-secondary IntVit IV Secondary
http://www.d3lexicon.com/affix/glorious IntVit IX
http://www.d3lexicon.com/affix/int-vit-ix-secondary IntVit IX Secondary
http://www.d3lexicon.com/affix/vaunted IntVit V
http://www.d3lexicon.com/affix/vaunted-2 IntVit VI
http://www.d3lexicon.com/affix/vaunted-3 IntVit VII
http://www.d3lexicon.com/affix/vaunted-4 IntVit VIII
http://www.d3lexicon.com/affix/int-vit-viii-secondary IntVit VIII Secondary
http://www.d3lexicon.com/affix/int-vit-vii-secondary IntVit VII Secondary
http://www.d3lexicon.com/affix/int-vit-vi-secondary IntVit VI Secondary
http://www.d3lexicon.com/affix/int-vit-v-secondary IntVit V Secondary
http://www.d3lexicon.com/affix/glorious-2 IntVit X
http://www.d3lexicon.com/affix/glorious-3 IntVit XI
http://www.d3lexicon.com/affix/illustrious IntVit XII
http://www.d3lexicon.com/affix/int-vit-xii-secondary IntVit XII Secondary
http://www.d3lexicon.com/affix/int-vit-xi-secondary IntVit XI Secondary
http://www.d3lexicon.com/affix/int-vit-x-secondary IntVit X Secondary
http://www.d3lexicon.com/affix/of-slaughter KillLife 1
http://www.d3lexicon.com/affix/kill-life-1-secondary KillLife 1 Secondary
http://www.d3lexicon.com/affix/of-slaughter-2 KillLife 2
http://www.d3lexicon.com/affix/kill-life-2-secondary KillLife 2 Secondary
http://www.d3lexicon.com/affix/of-slaughter-3 KillLife 3
http://www.d3lexicon.com/affix/kill-life-3-secondary KillLife 3 Secondary
http://www.d3lexicon.com/affix/of-slaughter-4 KillLife 4
http://www.d3lexicon.com/affix/kill-life-4-secondary KillLife 4 Secondary
http://www.d3lexicon.com/affix/of-slaughter-5 KillLife 5
http://www.d3lexicon.com/affix/kill-life-5-secondary KillLife 5 Secondary
http://www.d3lexicon.com/affix/of-mutilation KillLife 6
http://www.d3lexicon.com/affix/kill-life-6-secondary KillLife 6 Secondary
http://www.d3lexicon.com/affix/of-mutilation-2 KillLife 7
http://www.d3lexicon.com/affix/kill-life-7-secondary KillLife 7 Secondary
http://www.d3lexicon.com/affix/of-mutilation-3 KillLife 8
http://www.d3lexicon.com/affix/kill-life-8-secondary KillLife 8 Secondary
http://www.d3lexicon.com/affix/of-mutilation-4 KillLife 9
http://www.d3lexicon.com/affix/kill-life-9-secondary KillLife 9 Secondary
http://www.d3lexicon.com/affix/of-extermination KillLife 10
http://www.d3lexicon.com/affix/kill-life-10-secondary KillLife 10 Secondary
http://www.d3lexicon.com/affix/of-extermination-2 KillLife 11
http://www.d3lexicon.com/affix/kill-life-11-secondary KillLife 11 Secondary
http://www.d3lexicon.com/affix/of-extermination-3 KillLife 12
http://www.d3lexicon.com/affix/kill-life-12-secondary KillLife 12 Secondary
http://www.d3lexicon.com/affix/of-extermination-4 KillLife 13
http://www.d3lexicon.com/affix/kill-life-13-secondary KillLife 13 Secondary
http://www.d3lexicon.com/affix/kill-life-14 KillLife 14
http://www.d3lexicon.com/affix/kill-life-14-secondary KillLife 14 Secondary
http://www.d3lexicon.com/affix/of-decimation KillMana 1
http://www.d3lexicon.com/affix/of-decimation-2 KillMana 2
http://www.d3lexicon.com/affix/of-decimation-3 KillMana 3
http://www.d3lexicon.com/affix/of-decimation-4 KillMana 4
http://www.d3lexicon.com/affix/of-eradication KillMana 5
http://www.d3lexicon.com/affix/of-eradication-2 KillMana 6
http://www.d3lexicon.com/affix/of-eradication-3 KillMana 7
http://www.d3lexicon.com/affix/of-eradication-4 KillMana 8
http://www.d3lexicon.com/affix/of-obliteration KillMana 9
http://www.d3lexicon.com/affix/of-obliteration-2 KillMana 10
http://www.d3lexicon.com/affix/of-obliteration-3 KillMana 11
http://www.d3lexicon.com/affix/of-annihilation KillMana 12
http://www.d3lexicon.com/affix/noble Kings I
http://www.d3lexicon.com/affix/noble-2 Kings II
http://www.d3lexicon.com/affix/noble-3 Kings III
http://www.d3lexicon.com/affix/kings-iii-secondary Kings III Secondary
http://www.d3lexicon.com/affix/kings-ii-secondary Kings II Secondary
http://www.d3lexicon.com/affix/kings-i-secondary Kings I Secondary
http://www.d3lexicon.com/affix/royal Kings IV
http://www.d3lexicon.com/affix/kings-iv-secondary Kings IV Secondary
http://www.d3lexicon.com/affix/royal-2 Kings V
http://www.d3lexicon.com/affix/royal-3 Kings VI
http://www.d3lexicon.com/affix/imperial Kings VII
http://www.d3lexicon.com/affix/kings-vii-secondary Kings VII Secondary
http://www.d3lexicon.com/affix/kings-vi-secondary Kings VI Secondary
http://www.d3lexicon.com/affix/kings-v-secondary Kings V Secondary
http://www.d3lexicon.com/affix/knight-i Knight I
http://www.d3lexicon.com/affix/life-01-legendary Life 0.1 Legendary
http://www.d3lexicon.com/affix/life-01-secondary-legendary Life 0.1 Secondary Legendary
http://www.d3lexicon.com/affix/life-02-legendary Life 0.2 Legendary
http://www.d3lexicon.com/affix/life-02-secondary-legendary Life 0.2 Secondary Legendary
http://www.d3lexicon.com/affix/life-03-legendary Life 0.3 Legendary
http://www.d3lexicon.com/affix/life-03-secondary-legendary Life 0.3 Secondary Legendary
http://www.d3lexicon.com/affix/rugged Life I
http://www.d3lexicon.com/affix/rugged-2 Life II
http://www.d3lexicon.com/affix/rugged-3 Life III
http://www.d3lexicon.com/affix/life-iii-secondary Life III Secondary
http://www.d3lexicon.com/affix/life-ii-secondary Life II Secondary
http://www.d3lexicon.com/affix/life-i-secondary Life I Secondary
http://www.d3lexicon.com/affix/stalwart Life IV
http://www.d3lexicon.com/affix/life-iv-secondary Life IV Secondary
http://www.d3lexicon.com/affix/vampiric LifeS 1
http://www.d3lexicon.com/affix/vampiric-2 LifeS 2
http://www.d3lexicon.com/affix/fiendish LifeS 3
http://www.d3lexicon.com/affix/fiendish-2 LifeS 4
http://www.d3lexicon.com/affix/gruesome LifeS 5
http://www.d3lexicon.com/affix/gruesome-2 LifeS 6
http://www.d3lexicon.com/affix/exsanguinating LifeS 7
http://www.d3lexicon.com/affix/stalwart-2 Life V
http://www.d3lexicon.com/affix/stalwart-3 Life VI
http://www.d3lexicon.com/affix/life-vi-secondary Life VI Secondary
http://www.d3lexicon.com/affix/life-v-secondary Life V Secondary
http://www.d3lexicon.com/affix/of-the-eel LightningD 1
http://www.d3lexicon.com/affix/lightning-damage-1-fast LightningD 1 Fast
http://www.d3lexicon.com/affix/of-the-eel-2 LightningD 2
http://www.d3lexicon.com/affix/lightning-damage-2-fast LightningD 2 Fast
http://www.d3lexicon.com/affix/of-the-eel-3 LightningD 3
http://www.d3lexicon.com/affix/lightning-damage-3-fast LightningD 3 Fast
http://www.d3lexicon.com/affix/of-the-eel-4 LightningD 4
http://www.d3lexicon.com/affix/lightning-damage-4-fast LightningD 4 Fast
http://www.d3lexicon.com/affix/of-storms LightningD 5
http://www.d3lexicon.com/affix/lightning-damage-5-fast LightningD 5 Fast
http://www.d3lexicon.com/affix/of-storms-2 LightningD 6
http://www.d3lexicon.com/affix/lightning-damage-6-fast LightningD 6 Fast
http://www.d3lexicon.com/affix/of-storms-3 LightningD 7
http://www.d3lexicon.com/affix/lightning-damage-7-fast LightningD 7 Fast
http://www.d3lexicon.com/affix/of-storms-4 LightningD 8
http://www.d3lexicon.com/affix/lightning-damage-8-fast LightningD 8 Fast
http://www.d3lexicon.com/affix/of-storms-5 LightningD 9
http://www.d3lexicon.com/affix/lightning-damage-9-fast LightningD 9 Fast
http://www.d3lexicon.com/affix/of-discord LightningD 10
http://www.d3lexicon.com/affix/lightning-damage-10-fast LightningD 10 Fast
http://www.d3lexicon.com/affix/of-discord-2 LightningD 11
http://www.d3lexicon.com/affix/lightning-damage-11-fast LightningD 11 Fast
http://www.d3lexicon.com/affix/of-discord-3 LightningD 12
http://www.d3lexicon.com/affix/lightning-damage-12-fast LightningD 12 Fast
http://www.d3lexicon.com/affix/of-discord-4 LightningD 13
http://www.d3lexicon.com/affix/lightning-damage-13-fast LightningD 13 Fast
http://www.d3lexicon.com/affix/of-conflagration LightningD 14
http://www.d3lexicon.com/affix/lightning-damage-14-fast LightningD 14 Fast
http://www.d3lexicon.com/affix/lightning-resist-01-legendary LightningResist 0.1 Legendary
http://www.d3lexicon.com/affix/lightning-resist-02-legendary LightningResist 0.2 Legendary
http://www.d3lexicon.com/affix/lightning-resist-03-legendary LightningResist 0.3 Legendary
http://www.d3lexicon.com/affix/silent LightningResist I
http://www.d3lexicon.com/affix/silent-2 LightningResist II
http://www.d3lexicon.com/affix/silent-3 LightningResist III
http://www.d3lexicon.com/affix/silent-4 LightningResist IV
http://www.d3lexicon.com/affix/stable LightningResist IX
http://www.d3lexicon.com/affix/tranquil LightningResist V
http://www.d3lexicon.com/affix/tranquil-2 LightningResist VI
http://www.d3lexicon.com/affix/tranquil-3 LightningResist VII
http://www.d3lexicon.com/affix/tranquil-4 LightningResist VIII
http://www.d3lexicon.com/affix/stable-2 LightningResist X
http://www.d3lexicon.com/affix/stable-3 LightningResist XI
http://www.d3lexicon.com/affix/serene LightningResist XII
http://www.d3lexicon.com/affix/lower-resist-i Lower Resist I
http://www.d3lexicon.com/affix/loyalty-i Loyalty I
http://www.d3lexicon.com/affix/infusing ManaRegen 1
http://www.d3lexicon.com/affix/infusing-2 ManaRegen 2
http://www.d3lexicon.com/affix/infusing-3 ManaRegen 3
http://www.d3lexicon.com/affix/replenishing ManaRegen 4
http://www.d3lexicon.com/affix/replenishing-2 ManaRegen 5
http://www.d3lexicon.com/affix/replenishing-3 ManaRegen 6
http://www.d3lexicon.com/affix/energizing ManaRegen 7
http://www.d3lexicon.com/affix/energizing-2 ManaRegen 8
http://www.d3lexicon.com/affix/energizing-3 ManaRegen 9
http://www.d3lexicon.com/affix/intensifying ManaRegen 10
http://www.d3lexicon.com/affix/sly MaxArcanePower 1
http://www.d3lexicon.com/affix/max-arcane-power-1-legendary MaxArcanePower 1 Legendary
http://www.d3lexicon.com/affix/sly-2 MaxArcanePower 2
http://www.d3lexicon.com/affix/max-arcane-power-2-legendary MaxArcanePower 2 Legendary
http://www.d3lexicon.com/affix/sly-3 MaxArcanePower 3
http://www.d3lexicon.com/affix/max-arcane-power-3-legendary MaxArcanePower 3 Legendary
http://www.d3lexicon.com/affix/mental MaxArcanePower 4
http://www.d3lexicon.com/affix/max-arcane-power-4-legendary MaxArcanePower 4 Legendary
http://www.d3lexicon.com/affix/mental-2 MaxArcanePower 5
http://www.d3lexicon.com/affix/max-arcane-power-5-legendary MaxArcanePower 5 Legendary
http://www.d3lexicon.com/affix/max-arcane-power-6-legendary MaxArcanePower 6 Legendary
http://www.d3lexicon.com/affix/max-arcane-power-7-legendary MaxArcanePower 7 Legendary
http://www.d3lexicon.com/affix/max-arcane-power-8-legendary MaxArcanePower 8 Legendary
http://www.d3lexicon.com/affix/max-arcane-power-9-legendary MaxArcanePower 9 Legendary
http://www.d3lexicon.com/affix/max-arcane-power-10-legendary MaxArcanePower 10 Legendary
http://www.d3lexicon.com/affix/of-thrashing MaxDam 1
http://www.d3lexicon.com/affix/max-dam-1-fast MaxDam 1 Fast
http://www.d3lexicon.com/affix/max-dam-1-secondary MaxDam 1 Secondary
http://www.d3lexicon.com/affix/of-thrashing-2 MaxDam 2
http://www.d3lexicon.com/affix/max-dam-2-fast MaxDam 2 Fast
http://www.d3lexicon.com/affix/max-dam-2-secondary MaxDam 2 Secondary
http://www.d3lexicon.com/affix/of-thrashing-3 MaxDam 3
http://www.d3lexicon.com/affix/max-dam-3-fast MaxDam 3 Fast
http://www.d3lexicon.com/affix/max-dam-3-secondary MaxDam 3 Secondary
http://www.d3lexicon.com/affix/of-thrashing-4 MaxDam 4
http://www.d3lexicon.com/affix/max-dam-4-fast MaxDam 4 Fast
http://www.d3lexicon.com/affix/max-dam-4-secondary MaxDam 4 Secondary
http://www.d3lexicon.com/affix/of-maiming MaxDam 5
http://www.d3lexicon.com/affix/max-dam-5-fast MaxDam 5 Fast
http://www.d3lexicon.com/affix/max-dam-5-secondary MaxDam 5 Secondary
http://www.d3lexicon.com/affix/of-maiming-2 MaxDam 6
http://www.d3lexicon.com/affix/max-dam-6-fast MaxDam 6 Fast
http://www.d3lexicon.com/affix/max-dam-6-secondary MaxDam 6 Secondary
http://www.d3lexicon.com/affix/of-maiming-3 MaxDam 7
http://www.d3lexicon.com/affix/max-dam-7-fast MaxDam 7 Fast
http://www.d3lexicon.com/affix/max-dam-7-secondary MaxDam 7 Secondary
http://www.d3lexicon.com/affix/of-maiming-4 MaxDam 8
http://www.d3lexicon.com/affix/max-dam-8-fast MaxDam 8 Fast
http://www.d3lexicon.com/affix/max-dam-8-secondary MaxDam 8 Secondary
http://www.d3lexicon.com/affix/of-maiming-5 MaxDam 9
http://www.d3lexicon.com/affix/max-dam-9-fast MaxDam 9 Fast
http://www.d3lexicon.com/affix/max-dam-9-secondary MaxDam 9 Secondary
http://www.d3lexicon.com/affix/of-strife MaxDam 10
http://www.d3lexicon.com/affix/max-dam-10-fast MaxDam 10 Fast
http://www.d3lexicon.com/affix/max-dam-10-secondary MaxDam 10 Secondary
http://www.d3lexicon.com/affix/of-strife-2 MaxDam 11
http://www.d3lexicon.com/affix/max-dam-11-fast MaxDam 11 Fast
http://www.d3lexicon.com/affix/max-dam-11-secondary MaxDam 11 Secondary
http://www.d3lexicon.com/affix/of-strife-3 MaxDam 12
http://www.d3lexicon.com/affix/max-dam-12-fast MaxDam 12 Fast
http://www.d3lexicon.com/affix/max-dam-12-secondary MaxDam 12 Secondary
http://www.d3lexicon.com/affix/of-strife-4 MaxDam 13
http://www.d3lexicon.com/affix/max-dam-13-fast MaxDam 13 Fast
http://www.d3lexicon.com/affix/max-dam-13-secondary MaxDam 13 Secondary
http://www.d3lexicon.com/affix/of-doom MaxDam 14
http://www.d3lexicon.com/affix/max-dam-14-fast MaxDam 14 Fast
http://www.d3lexicon.com/affix/max-dam-14-secondary MaxDam 14 Secondary
http://www.d3lexicon.com/affix/steady MaxDiscipline 1
http://www.d3lexicon.com/affix/max-discipline-1-legendary MaxDiscipline 1 Legendary
http://www.d3lexicon.com/affix/steady-2 MaxDiscipline 2
http://www.d3lexicon.com/affix/max-discipline-2-legendary MaxDiscipline 2 Legendary
http://www.d3lexicon.com/affix/steady-3 MaxDiscipline 3
http://www.d3lexicon.com/affix/max-discipline-3-legendary MaxDiscipline 3 Legendary
http://www.d3lexicon.com/affix/confident MaxDiscipline 4
http://www.d3lexicon.com/affix/max-discipline-4-legendary MaxDiscipline 4 Legendary
http://www.d3lexicon.com/affix/confident-2 MaxDiscipline 5
http://www.d3lexicon.com/affix/max-discipline-5-legendary MaxDiscipline 5 Legendary
http://www.d3lexicon.com/affix/max-discipline-6-legendary MaxDiscipline 6 Legendary
http://www.d3lexicon.com/affix/max-discipline-7-legendary MaxDiscipline 7 Legendary
http://www.d3lexicon.com/affix/max-discipline-8-legendary MaxDiscipline 8 Legendary
http://www.d3lexicon.com/affix/max-discipline-9-legendary MaxDiscipline 9 Legendary
http://www.d3lexicon.com/affix/max-discipline-10-legendary MaxDiscipline 10 Legendary
http://www.d3lexicon.com/affix/reckless MaxFury 1
http://www.d3lexicon.com/affix/max-fury-1-legendary MaxFury 1 Legendary
http://www.d3lexicon.com/affix/reckless-2 MaxFury 2
http://www.d3lexicon.com/affix/max-fury-2-legendary MaxFury 2 Legendary
http://www.d3lexicon.com/affix/reckless-3 MaxFury 3
http://www.d3lexicon.com/affix/max-fury-3-legendary MaxFury 3 Legendary
http://www.d3lexicon.com/affix/wrathful MaxFury 4
http://www.d3lexicon.com/affix/max-fury-4-legendary MaxFury 4 Legendary
http://www.d3lexicon.com/affix/wrathful-2 MaxFury 5
http://www.d3lexicon.com/affix/max-fury-5-legendary MaxFury 5 Legendary
http://www.d3lexicon.com/affix/max-fury-6-legendary MaxFury 6 Legendary
http://www.d3lexicon.com/affix/max-fury-7-legendary MaxFury 7 Legendary
http://www.d3lexicon.com/affix/max-fury-8-legendary MaxFury 8 Legendary
http://www.d3lexicon.com/affix/max-fury-9-legendary MaxFury 9 Legendary
http://www.d3lexicon.com/affix/max-fury-10-legendary MaxFury 10 Legendary
http://www.d3lexicon.com/affix/bewitching MaxMana 1
http://www.d3lexicon.com/affix/bewitching-2 MaxMana 2
http://www.d3lexicon.com/affix/bewitching-3 MaxMana 3
http://www.d3lexicon.com/affix/conjuring MaxMana 4
http://www.d3lexicon.com/affix/conjuring-2 MaxMana 5
http://www.d3lexicon.com/affix/conjuring-3 MaxMana 6
http://www.d3lexicon.com/affix/mesmerizing MaxMana 7
http://www.d3lexicon.com/affix/mesmerizing-2 MaxMana 8
http://www.d3lexicon.com/affix/mesmerizing-3 MaxMana 9
http://www.d3lexicon.com/affix/unearthly MaxMana 10
http://www.d3lexicon.com/affix/scouting MF I
http://www.d3lexicon.com/affix/scouting-2 MF II
http://www.d3lexicon.com/affix/scouting-3 MF III
http://www.d3lexicon.com/affix/mf-iii-secondary MF III Secondary
http://www.d3lexicon.com/affix/mf-ii-secondary MF II Secondary
http://www.d3lexicon.com/affix/mf-i-secondary MF I Secondary
http://www.d3lexicon.com/affix/scouting-4 MF IV
http://www.d3lexicon.com/affix/mf-iv-secondary MF IV Secondary
http://www.d3lexicon.com/affix/seeking-2 MF IX
http://www.d3lexicon.com/affix/mf-ix-secondary MF IX Secondary
http://www.d3lexicon.com/affix/ransacking MF V
http://www.d3lexicon.com/affix/ransacking-2 MF VI
http://www.d3lexicon.com/affix/ransacking-3 MF VII
http://www.d3lexicon.com/affix/seeking MF VIII
http://www.d3lexicon.com/affix/mf-viii-secondary MF VIII Secondary
http://www.d3lexicon.com/affix/mf-vii-secondary MF VII Secondary
http://www.d3lexicon.com/affix/mf-vi-secondary MF VI Secondary
http://www.d3lexicon.com/affix/mf-v-secondary MF V Secondary
http://www.d3lexicon.com/affix/of-slaying MinDam 1
http://www.d3lexicon.com/affix/min-dam-1-fast MinDam 1 Fast
http://www.d3lexicon.com/affix/min-dam-1-secondary MinDam 1 Secondary
http://www.d3lexicon.com/affix/of-slaying-2 MinDam 2
http://www.d3lexicon.com/affix/min-dam-2-fast MinDam 2 Fast
http://www.d3lexicon.com/affix/min-dam-2-secondary MinDam 2 Secondary
http://www.d3lexicon.com/affix/of-slaying-3 MinDam 3
http://www.d3lexicon.com/affix/min-dam-3-fast MinDam 3 Fast
http://www.d3lexicon.com/affix/min-dam-3-secondary MinDam 3 Secondary
http://www.d3lexicon.com/affix/of-slaying-4 MinDam 4
http://www.d3lexicon.com/affix/min-dam-4-fast MinDam 4 Fast
http://www.d3lexicon.com/affix/min-dam-4-secondary MinDam 4 Secondary
http://www.d3lexicon.com/affix/of-slaying-5 MinDam 5
http://www.d3lexicon.com/affix/min-dam-5-fast MinDam 5 Fast
http://www.d3lexicon.com/affix/min-dam-5-secondary MinDam 5 Secondary
http://www.d3lexicon.com/affix/of-destruction MinDam 6
http://www.d3lexicon.com/affix/min-dam-6-fast MinDam 6 Fast
http://www.d3lexicon.com/affix/min-dam-6-secondary MinDam 6 Secondary
http://www.d3lexicon.com/affix/of-destruction-2 MinDam 7
http://www.d3lexicon.com/affix/min-dam-7-fast MinDam 7 Fast
http://www.d3lexicon.com/affix/min-dam-7-secondary MinDam 7 Secondary
http://www.d3lexicon.com/affix/of-destruction-3 MinDam 8
http://www.d3lexicon.com/affix/min-dam-8-fast MinDam 8 Fast
http://www.d3lexicon.com/affix/min-dam-8-secondary MinDam 8 Secondary
http://www.d3lexicon.com/affix/of-destruction-4 MinDam 9
http://www.d3lexicon.com/affix/min-dam-9-fast MinDam 9 Fast
http://www.d3lexicon.com/affix/min-dam-9-secondary MinDam 9 Secondary
http://www.d3lexicon.com/affix/of-severing MinDam 10
http://www.d3lexicon.com/affix/min-dam-10-fast MinDam 10 Fast
http://www.d3lexicon.com/affix/min-dam-10-secondary MinDam 10 Secondary
http://www.d3lexicon.com/affix/of-severing-2 MinDam 11
http://www.d3lexicon.com/affix/min-dam-11-fast MinDam 11 Fast
http://www.d3lexicon.com/affix/min-dam-11-secondary MinDam 11 Secondary
http://www.d3lexicon.com/affix/of-severing-3 MinDam 12
http://www.d3lexicon.com/affix/min-dam-12-fast MinDam 12 Fast
http://www.d3lexicon.com/affix/min-dam-12-secondary MinDam 12 Secondary
http://www.d3lexicon.com/affix/of-severing-4 MinDam 13
http://www.d3lexicon.com/affix/min-dam-13-fast MinDam 13 Fast
http://www.d3lexicon.com/affix/min-dam-13-secondary MinDam 13 Secondary
http://www.d3lexicon.com/affix/of-devastation MinDam 14
http://www.d3lexicon.com/affix/min-dam-14-fast MinDam 14 Fast
http://www.d3lexicon.com/affix/min-dam-14-secondary MinDam 14 Secondary
http://www.d3lexicon.com/affix/of-wounding MinMaxDam 1
http://www.d3lexicon.com/affix/min-max-dam-1-fast MinMaxDam 1 Fast
http://www.d3lexicon.com/affix/min-max-dam-1-secondary MinMaxDam 1 Secondary
http://www.d3lexicon.com/affix/of-wounding-2 MinMaxDam 2
http://www.d3lexicon.com/affix/min-max-dam-2-fast MinMaxDam 2 Fast
http://www.d3lexicon.com/affix/min-max-dam-2-secondary MinMaxDam 2 Secondary
http://www.d3lexicon.com/affix/of-wounding-3 MinMaxDam 3
http://www.d3lexicon.com/affix/min-max-dam-3-fast MinMaxDam 3 Fast
http://www.d3lexicon.com/affix/min-max-dam-3-secondary MinMaxDam 3 Secondary
http://www.d3lexicon.com/affix/of-wounding-4 MinMaxDam 4
http://www.d3lexicon.com/affix/min-max-dam-4-fast MinMaxDam 4 Fast
http://www.d3lexicon.com/affix/min-max-dam-4-secondary MinMaxDam 4 Secondary
http://www.d3lexicon.com/affix/of-agony MinMaxDam 5
http://www.d3lexicon.com/affix/min-max-dam-5-fast MinMaxDam 5 Fast
http://www.d3lexicon.com/affix/min-max-dam-5-secondary MinMaxDam 5 Secondary
http://www.d3lexicon.com/affix/of-agony-2 MinMaxDam 6
http://www.d3lexicon.com/affix/min-max-dam-6-fast MinMaxDam 6 Fast
http://www.d3lexicon.com/affix/min-max-dam-6-secondary MinMaxDam 6 Secondary
http://www.d3lexicon.com/affix/of-agony-3 MinMaxDam 7
http://www.d3lexicon.com/affix/min-max-dam-7-fast MinMaxDam 7 Fast
http://www.d3lexicon.com/affix/min-max-dam-7-secondary MinMaxDam 7 Secondary
http://www.d3lexicon.com/affix/of-agony-4 MinMaxDam 8
http://www.d3lexicon.com/affix/min-max-dam-8-fast MinMaxDam 8 Fast
http://www.d3lexicon.com/affix/min-max-dam-8-secondary MinMaxDam 8 Secondary
http://www.d3lexicon.com/affix/of-malice MinMaxDam 9
http://www.d3lexicon.com/affix/min-max-dam-9-fast MinMaxDam 9 Fast
http://www.d3lexicon.com/affix/min-max-dam-9-secondary MinMaxDam 9 Secondary
http://www.d3lexicon.com/affix/of-malice-2 MinMaxDam 10
http://www.d3lexicon.com/affix/min-max-dam-10-fast MinMaxDam 10 Fast
http://www.d3lexicon.com/affix/min-max-dam-10-secondary MinMaxDam 10 Secondary
http://www.d3lexicon.com/affix/of-malice-3 MinMaxDam 11
http://www.d3lexicon.com/affix/min-max-dam-11-fast MinMaxDam 11 Fast
http://www.d3lexicon.com/affix/min-max-dam-11-secondary MinMaxDam 11 Secondary
http://www.d3lexicon.com/affix/of-malice-4 MinMaxDam 12
http://www.d3lexicon.com/affix/min-max-dam-12-fast MinMaxDam 12 Fast
http://www.d3lexicon.com/affix/min-max-dam-12-secondary MinMaxDam 12 Secondary
http://www.d3lexicon.com/affix/of-malice-5 MinMaxDam 13
http://www.d3lexicon.com/affix/min-max-dam-13-fast MinMaxDam 13 Fast
http://www.d3lexicon.com/affix/min-max-dam-13-secondary MinMaxDam 13 Secondary
http://www.d3lexicon.com/affix/of-death MinMaxDam 14
http://www.d3lexicon.com/affix/min-max-dam-14-fast MinMaxDam 14 Fast
http://www.d3lexicon.com/affix/min-max-dam-14-secondary MinMaxDam 14 Secondary
http://www.d3lexicon.com/affix/multishot-i Multishot I
http://www.d3lexicon.com/affix/onslaught-i Onslaught I
http://www.d3lexicon.com/affix/physical-resist-01-legendary PhysicalResist 0.1 Legendary
http://www.d3lexicon.com/affix/physical-resist-02-legendary PhysicalResist 0.2 Legendary
http://www.d3lexicon.com/affix/physical-resist-03-legendary PhysicalResist 0.3 Legendary
http://www.d3lexicon.com/affix/hardened PhysicalResist I
http://www.d3lexicon.com/affix/hardened-2 PhysicalResist II
http://www.d3lexicon.com/affix/hardened-3 PhysicalResist III
http://www.d3lexicon.com/affix/hardened-4 PhysicalResist IV
http://www.d3lexicon.com/affix/untouchable PhysicalResist IX
http://www.d3lexicon.com/affix/hermetic PhysicalResist V
http://www.d3lexicon.com/affix/hermetic-2 PhysicalResist VI
http://www.d3lexicon.com/affix/hermetic-3 PhysicalResist VII
http://www.d3lexicon.com/affix/hermetic-4 PhysicalResist VIII
http://www.d3lexicon.com/affix/untouchable-2 PhysicalResist X
http://www.d3lexicon.com/affix/untouchable-3 PhysicalResist XI
http://www.d3lexicon.com/affix/adamantine PhysicalResist XII
http://www.d3lexicon.com/affix/poison-arrow-i Poison Arrow I
http://www.d3lexicon.com/affix/of-the-snake PoisonD 1
http://www.d3lexicon.com/affix/poison-damage-1-fast PoisonD 1 Fast
http://www.d3lexicon.com/affix/of-the-snake-2 PoisonD 2
http://www.d3lexicon.com/affix/poison-damage-2-fast PoisonD 2 Fast
http://www.d3lexicon.com/affix/of-the-snake-3 PoisonD 3
http://www.d3lexicon.com/affix/poison-damage-3-fast PoisonD 3 Fast
http://www.d3lexicon.com/affix/of-the-snake-4 PoisonD 4
http://www.d3lexicon.com/affix/poison-damage-4-fast PoisonD 4 Fast
http://www.d3lexicon.com/affix/of-lesions PoisonD 5
http://www.d3lexicon.com/affix/poison-damage-5-fast PoisonD 5 Fast
http://www.d3lexicon.com/affix/of-lesions-2 PoisonD 6
http://www.d3lexicon.com/affix/poison-damage-6-fast PoisonD 6 Fast
http://www.d3lexicon.com/affix/of-lesions-3 PoisonD 7
http://www.d3lexicon.com/affix/poison-damage-7-fast PoisonD 7 Fast
http://www.d3lexicon.com/affix/of-lesions-4 PoisonD 8
http://www.d3lexicon.com/affix/poison-damage-8-fast PoisonD 8 Fast
http://www.d3lexicon.com/affix/of-sores PoisonD 9
http://www.d3lexicon.com/affix/poison-damage-9-fast PoisonD 9 Fast
http://www.d3lexicon.com/affix/of-sores-2 PoisonD 10
http://www.d3lexicon.com/affix/poison-damage-10-fast PoisonD 10 Fast
http://www.d3lexicon.com/affix/of-sores-3 PoisonD 11
http://www.d3lexicon.com/affix/poison-damage-11-fast PoisonD 11 Fast
http://www.d3lexicon.com/affix/of-sores-4 PoisonD 12
http://www.d3lexicon.com/affix/poison-damage-12-fast PoisonD 12 Fast
http://www.d3lexicon.com/affix/of-sores-5 PoisonD 13
http://www.d3lexicon.com/affix/poison-damage-13-fast PoisonD 13 Fast
http://www.d3lexicon.com/affix/of-blight PoisonD 14
http://www.d3lexicon.com/affix/poison-damage-14-fast PoisonD 14 Fast
http://www.d3lexicon.com/affix/poison-resist-01-legendary PoisonResist 0.1 Legendary
http://www.d3lexicon.com/affix/poison-resist-02-legendary PoisonResist 0.2 Legendary
http://www.d3lexicon.com/affix/poison-resist-03-legendary PoisonResist 0.3 Legendary
http://www.d3lexicon.com/affix/pure PoisonResist I
http://www.d3lexicon.com/affix/pure-2 PoisonResist II
http://www.d3lexicon.com/affix/pure-3 PoisonResist III
http://www.d3lexicon.com/affix/pure-4 PoisonResist IV
http://www.d3lexicon.com/affix/pristine PoisonResist IX
http://www.d3lexicon.com/affix/untarnished PoisonResist V
http://www.d3lexicon.com/affix/untarnished-2 PoisonResist VI
http://www.d3lexicon.com/affix/untarnished-3 PoisonResist VII
http://www.d3lexicon.com/affix/untarnished-4 PoisonResist VIII
http://www.d3lexicon.com/affix/pristine-2 PoisonResist X
http://www.d3lexicon.com/affix/pristine-3 PoisonResist XI
http://www.d3lexicon.com/affix/immaculate PoisonResist XII
http://www.d3lexicon.com/affix/powered-armor-i Powered Armor I
http://www.d3lexicon.com/affix/power-shot-i Power Shot I
http://www.d3lexicon.com/affix/primary-attribute-dex-1-legendary PrimaryAttribute_Dex 1 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-2-legendary PrimaryAttribute_Dex 2 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-3-legendary PrimaryAttribute_Dex 3 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-4-legendary PrimaryAttribute_Dex 4 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-5-legendary PrimaryAttribute_Dex 5 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-6-legendary PrimaryAttribute_Dex 6 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-7-legendary PrimaryAttribute_Dex 7 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-8-legendary PrimaryAttribute_Dex 8 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-9-legendary PrimaryAttribute_Dex 9 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-10-legendary PrimaryAttribute_Dex 10 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-11-legendary PrimaryAttribute_Dex 11 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-12-legendary PrimaryAttribute_Dex 12 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-13-legendary PrimaryAttribute_Dex 13 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-14-legendary PrimaryAttribute_Dex 14 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-15-legendary PrimaryAttribute_Dex 15 Legendary
http://www.d3lexicon.com/affix/primary-attribute-dex-16-legendary PrimaryAttribute_Dex 16 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-1-legendary PrimaryAttribute_Int 1 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-2-legendary PrimaryAttribute_Int 2 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-3-legendary PrimaryAttribute_Int 3 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-4-legendary PrimaryAttribute_Int 4 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-5-legendary PrimaryAttribute_Int 5 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-6-legendary PrimaryAttribute_Int 6 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-7-legendary PrimaryAttribute_Int 7 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-8-legendary PrimaryAttribute_Int 8 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-9-legendary PrimaryAttribute_Int 9 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-10-legendary PrimaryAttribute_Int 10 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-11-legendary PrimaryAttribute_Int 11 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-12-legendary PrimaryAttribute_Int 12 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-13-legendary PrimaryAttribute_Int 13 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-14-legendary PrimaryAttribute_Int 14 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-15-legendary PrimaryAttribute_Int 15 Legendary
http://www.d3lexicon.com/affix/primary-attribute-int-16-legendary PrimaryAttribute_Int 16 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-1-legendary PrimaryAttribute_Str 1 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-2-legendary PrimaryAttribute_Str 2 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-3-legendary PrimaryAttribute_Str 3 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-4-legendary PrimaryAttribute_Str 4 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-5-legendary PrimaryAttribute_Str 5 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-6-legendary PrimaryAttribute_Str 6 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-7-legendary PrimaryAttribute_Str 7 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-8-legendary PrimaryAttribute_Str 8 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-9-legendary PrimaryAttribute_Str 9 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-10-legendary PrimaryAttribute_Str 10 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-11-legendary PrimaryAttribute_Str 11 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-12-legendary PrimaryAttribute_Str 12 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-13-legendary PrimaryAttribute_Str 13 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-14-legendary PrimaryAttribute_Str 14 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-15-legendary PrimaryAttribute_Str 15 Legendary
http://www.d3lexicon.com/affix/primary-attribute-str-16-legendary PrimaryAttribute_Str 16 Legendary
http://www.d3lexicon.com/affix/protection-i Protection I
http://www.d3lexicon.com/affix/rain-of-gold-i Rain of Gold I
http://www.d3lexicon.com/affix/rapid-fire-i Rapid Fire I
http://www.d3lexicon.com/affix/of-recognized-prefix RecognizedPrefix
http://www.d3lexicon.com/affix/of-recognized-suffix RecognizedSuffix
http://www.d3lexicon.com/affix/reflect-missiles-i Reflect Missiles I
http://www.d3lexicon.com/affix/reptilian Regen 1
http://www.d3lexicon.com/affix/regen-1-secondary Regen 1 Secondary
http://www.d3lexicon.com/affix/reptilian-2 Regen 2
http://www.d3lexicon.com/affix/regen-2-secondary Regen 2 Secondary
http://www.d3lexicon.com/affix/reptilian-3 Regen 3
http://www.d3lexicon.com/affix/regen-3-secondary Regen 3 Secondary
http://www.d3lexicon.com/affix/reptilian-4 Regen 4
http://www.d3lexicon.com/affix/regen-4-secondary Regen 4 Secondary
http://www.d3lexicon.com/affix/reptilian-5 Regen 5
http://www.d3lexicon.com/affix/regen-5-secondary Regen 5 Secondary
http://www.d3lexicon.com/affix/reptilian-6 Regen 6
http://www.d3lexicon.com/affix/regen-6-secondary Regen 6 Secondary
http://www.d3lexicon.com/affix/salubrious Regen 7
http://www.d3lexicon.com/affix/regen-7-secondary Regen 7 Secondary
http://www.d3lexicon.com/affix/salubrious-2 Regen 8
http://www.d3lexicon.com/affix/regen-8-secondary Regen 8 Secondary
http://www.d3lexicon.com/affix/salubrious-3 Regen 9
http://www.d3lexicon.com/affix/regen-9-secondary Regen 9 Secondary
http://www.d3lexicon.com/affix/salubrious-4 Regen 10
http://www.d3lexicon.com/affix/regen-10-secondary Regen 10 Secondary
http://www.d3lexicon.com/affix/salubrious-5 Regen 11
http://www.d3lexicon.com/affix/regen-11-secondary Regen 11 Secondary
http://www.d3lexicon.com/affix/salubrious-6 Regen 12
http://www.d3lexicon.com/affix/regen-12-secondary Regen 12 Secondary
http://www.d3lexicon.com/affix/undying Regen 13
http://www.d3lexicon.com/affix/regen-13-secondary Regen 13 Secondary
http://www.d3lexicon.com/affix/undying-2 Regen 14
http://www.d3lexicon.com/affix/regen-14-secondary Regen 14 Secondary
http://www.d3lexicon.com/affix/undying-3 Regen 15
http://www.d3lexicon.com/affix/regen-15-secondary Regen 15 Secondary
http://www.d3lexicon.com/affix/undying-4 Regen 16
http://www.d3lexicon.com/affix/regen-16-secondary Regen 16 Secondary
http://www.d3lexicon.com/affix/undying-5 Regen 17
http://www.d3lexicon.com/affix/regen-17-secondary Regen 17 Secondary
http://www.d3lexicon.com/affix/immortal Regen 18
http://www.d3lexicon.com/affix/regen-18-secondary Regen 18 Secondary
http://www.d3lexicon.com/affix/of-the-squire REQ 1
http://www.d3lexicon.com/affix/of-the-squire-2 REQ 2
http://www.d3lexicon.com/affix/of-the-squire-3 REQ 3
http://www.d3lexicon.com/affix/of-the-squire-4 REQ 4
http://www.d3lexicon.com/affix/of-the-squire-5 REQ 5
http://www.d3lexicon.com/affix/of-the-squire-6 REQ 6
http://www.d3lexicon.com/affix/of-courage REQ 7
http://www.d3lexicon.com/affix/of-courage-2 REQ 8
http://www.d3lexicon.com/affix/of-courage-3 REQ 9
http://www.d3lexicon.com/affix/resist-all-01-legendary ResistAll 0.1 Legendary
http://www.d3lexicon.com/affix/resist-all-02-legendary ResistAll 0.2 Legendary
http://www.d3lexicon.com/affix/resist-all-03-legendary ResistAll 0.3 Legendary
http://www.d3lexicon.com/affix/spectral ResistAll I
http://www.d3lexicon.com/affix/spectral-2 ResistAll II
http://www.d3lexicon.com/affix/spectral-3 ResistAll III
http://www.d3lexicon.com/affix/spectral-4 ResistAll IV
http://www.d3lexicon.com/affix/chromatic ResistAll V
http://www.d3lexicon.com/affix/chromatic-2 ResistAll VI
http://www.d3lexicon.com/affix/chromatic-3 ResistAll VII
http://www.d3lexicon.com/affix/of-melting ResistFreeze 1
http://www.d3lexicon.com/affix/of-the-sergeant ResistRoot 1
http://www.d3lexicon.com/affix/of-insolence ResistStun 1
http://www.d3lexicon.com/affix/of-contempt ResistStunRootFreeze 1
http://www.d3lexicon.com/affix/quick Run 1
http://www.d3lexicon.com/affix/nimble Run 2
http://www.d3lexicon.com/affix/bounding Run 3
http://www.d3lexicon.com/affix/swift Run 4
http://www.d3lexicon.com/affix/fleet Run 5
http://www.d3lexicon.com/affix/scavenge-i Scavenge I
http://www.d3lexicon.com/affix/of-bruising Skill_Barbarian_Bash 1
http://www.d3lexicon.com/affix/of-bruising-2 Skill_Barbarian_Bash 2
http://www.d3lexicon.com/affix/of-bruising-3 Skill_Barbarian_Bash 3
http://www.d3lexicon.com/affix/of-bruising-4 Skill_Barbarian_Bash 4
http://www.d3lexicon.com/affix/of-bruising-5 Skill_Barbarian_Bash 5
http://www.d3lexicon.com/affix/of-bruising-6 Skill_Barbarian_Bash 6
http://www.d3lexicon.com/affix/of-bruising-7 Skill_Barbarian_Bash 7
http://www.d3lexicon.com/affix/of-bruising-8 Skill_Barbarian_Bash 8
http://www.d3lexicon.com/affix/of-sundering Skill_Barbarian_Cleave 1
http://www.d3lexicon.com/affix/of-sundering-2 Skill_Barbarian_Cleave 2
http://www.d3lexicon.com/affix/of-sundering-3 Skill_Barbarian_Cleave 3
http://www.d3lexicon.com/affix/of-sundering-4 Skill_Barbarian_Cleave 4
http://www.d3lexicon.com/affix/of-sundering-5 Skill_Barbarian_Cleave 5
http://www.d3lexicon.com/affix/of-sundering-6 Skill_Barbarian_Cleave 6
http://www.d3lexicon.com/affix/of-sundering-7 Skill_Barbarian_Cleave 7
http://www.d3lexicon.com/affix/of-sundering-8 Skill_Barbarian_Cleave 8
http://www.d3lexicon.com/affix/of-the-maniac Skill_Barbarian_Frenzy 1
http://www.d3lexicon.com/affix/of-the-maniac-2 Skill_Barbarian_Frenzy 2
http://www.d3lexicon.com/affix/of-the-maniac-3 Skill_Barbarian_Frenzy 3
http://www.d3lexicon.com/affix/of-the-maniac-4 Skill_Barbarian_Frenzy 4
http://www.d3lexicon.com/affix/of-the-maniac-5 Skill_Barbarian_Frenzy 5
http://www.d3lexicon.com/affix/of-the-maniac-6 Skill_Barbarian_Frenzy 6
http://www.d3lexicon.com/affix/of-the-maniac-7 Skill_Barbarian_Frenzy 7
http://www.d3lexicon.com/affix/of-the-maniac-8 Skill_Barbarian_Frenzy 8
http://www.d3lexicon.com/affix/of-demolition Skill_Barbarian_HotA 1
http://www.d3lexicon.com/affix/of-demolition-2 Skill_Barbarian_HotA 2
http://www.d3lexicon.com/affix/of-demolition-3 Skill_Barbarian_HotA 3
http://www.d3lexicon.com/affix/of-demolition-4 Skill_Barbarian_HotA 4
http://www.d3lexicon.com/affix/of-demolition-5 Skill_Barbarian_HotA 5
http://www.d3lexicon.com/affix/of-demolition-6 Skill_Barbarian_HotA 6
http://www.d3lexicon.com/affix/of-demolition-7 Skill_Barbarian_HotA 7
http://www.d3lexicon.com/affix/of-demolition-8 Skill_Barbarian_HotA 8
http://www.d3lexicon.com/affix/of-conquest Skill_Barbarian_Overpower 1
http://www.d3lexicon.com/affix/of-conquest-2 Skill_Barbarian_Overpower 2
http://www.d3lexicon.com/affix/of-conquest-3 Skill_Barbarian_Overpower 3
http://www.d3lexicon.com/affix/of-conquest-4 Skill_Barbarian_Overpower 4
http://www.d3lexicon.com/affix/of-conquest-5 Skill_Barbarian_Overpower 5
http://www.d3lexicon.com/affix/of-conquest-6 Skill_Barbarian_Overpower 6
http://www.d3lexicon.com/affix/of-conquest-7 Skill_Barbarian_Overpower 7
http://www.d3lexicon.com/affix/of-conquest-8 Skill_Barbarian_Overpower 8
http://www.d3lexicon.com/affix/of-evisceration Skill_Barbarian_Rend 1
http://www.d3lexicon.com/affix/of-evisceration-2 Skill_Barbarian_Rend 2
http://www.d3lexicon.com/affix/of-evisceration-3 Skill_Barbarian_Rend 3
http://www.d3lexicon.com/affix/of-evisceration-4 Skill_Barbarian_Rend 4
http://www.d3lexicon.com/affix/of-evisceration-5 Skill_Barbarian_Rend 5
http://www.d3lexicon.com/affix/of-evisceration-6 Skill_Barbarian_Rend 6
http://www.d3lexicon.com/affix/of-evisceration-7 Skill_Barbarian_Rend 7
http://www.d3lexicon.com/affix/of-evisceration-8 Skill_Barbarian_Rend 8
http://www.d3lexicon.com/affix/of-vengeance Skill_Barbarian_Revenge 1
http://www.d3lexicon.com/affix/of-vengeance-2 Skill_Barbarian_Revenge 2
http://www.d3lexicon.com/affix/of-vengeance-3 Skill_Barbarian_Revenge 3
http://www.d3lexicon.com/affix/of-vengeance-4 Skill_Barbarian_Revenge 4
http://www.d3lexicon.com/affix/of-vengeance-5 Skill_Barbarian_Revenge 5
http://www.d3lexicon.com/affix/of-vengeance-6 Skill_Barbarian_Revenge 6
http://www.d3lexicon.com/affix/of-vengeance-7 Skill_Barbarian_Revenge 7
http://www.d3lexicon.com/affix/of-vengeance-8 Skill_Barbarian_Revenge 8
http://www.d3lexicon.com/affix/of-shattering Skill_Barbarian_SeismicSlam 1
http://www.d3lexicon.com/affix/of-shattering-2 Skill_Barbarian_SeismicSlam 2
http://www.d3lexicon.com/affix/of-shattering-3 Skill_Barbarian_SeismicSlam 3
http://www.d3lexicon.com/affix/of-shattering-4 Skill_Barbarian_SeismicSlam 4
http://www.d3lexicon.com/affix/of-shattering-5 Skill_Barbarian_SeismicSlam 5
http://www.d3lexicon.com/affix/of-shattering-6 Skill_Barbarian_SeismicSlam 6
http://www.d3lexicon.com/affix/of-shattering-7 Skill_Barbarian_SeismicSlam 7
http://www.d3lexicon.com/affix/of-shattering-8 Skill_Barbarian_SeismicSlam 8
http://www.d3lexicon.com/affix/of-hurling Skill_Barbarian_WeaponThrow 1
http://www.d3lexicon.com/affix/of-hurling-2 Skill_Barbarian_WeaponThrow 2
http://www.d3lexicon.com/affix/of-hurling-3 Skill_Barbarian_WeaponThrow 3
http://www.d3lexicon.com/affix/of-hurling-4 Skill_Barbarian_WeaponThrow 4
http://www.d3lexicon.com/affix/of-hurling-5 Skill_Barbarian_WeaponThrow 5
http://www.d3lexicon.com/affix/of-hurling-6 Skill_Barbarian_WeaponThrow 6
http://www.d3lexicon.com/affix/of-hurling-7 Skill_Barbarian_WeaponThrow 7
http://www.d3lexicon.com/affix/of-hurling-8 Skill_Barbarian_WeaponThrow 8
http://www.d3lexicon.com/affix/of-vertigo Skill_Barbarian_Whirlwind 1
http://www.d3lexicon.com/affix/of-vertigo-2 Skill_Barbarian_Whirlwind 2
http://www.d3lexicon.com/affix/of-vertigo-3 Skill_Barbarian_Whirlwind 3
http://www.d3lexicon.com/affix/of-vertigo-4 Skill_Barbarian_Whirlwind 4
http://www.d3lexicon.com/affix/of-vertigo-5 Skill_Barbarian_Whirlwind 5
http://www.d3lexicon.com/affix/of-vertigo-6 Skill_Barbarian_Whirlwind 6
http://www.d3lexicon.com/affix/of-vertigo-7 Skill_Barbarian_Whirlwind 7
http://www.d3lexicon.com/affix/of-vertigo-8 Skill_Barbarian_Whirlwind 8
http://www.d3lexicon.com/affix/of-the-bounty-hunter Skill_DemonHunter_BolaShot 1
http://www.d3lexicon.com/affix/of-the-bounty-hunter-2 Skill_DemonHunter_BolaShot 2
http://www.d3lexicon.com/affix/of-the-bounty-hunter-3 Skill_DemonHunter_BolaShot 3
http://www.d3lexicon.com/affix/of-the-bounty-hunter-4 Skill_DemonHunter_BolaShot 4
http://www.d3lexicon.com/affix/of-the-bounty-hunter-5 Skill_DemonHunter_BolaShot 5
http://www.d3lexicon.com/affix/of-the-bounty-hunter-6 Skill_DemonHunter_BolaShot 6
http://www.d3lexicon.com/affix/of-the-bounty-hunter-7 Skill_DemonHunter_BolaShot 7
http://www.d3lexicon.com/affix/of-the-bounty-hunter-8 Skill_DemonHunter_BolaShot 8
http://www.d3lexicon.com/affix/of-the-boomerang Skill_DemonHunter_Chakram 1
http://www.d3lexicon.com/affix/of-the-boomerang-2 Skill_DemonHunter_Chakram 2
http://www.d3lexicon.com/affix/of-the-boomerang-3 Skill_DemonHunter_Chakram 3
http://www.d3lexicon.com/affix/of-the-boomerang-4 Skill_DemonHunter_Chakram 4
http://www.d3lexicon.com/affix/of-the-boomerang-5 Skill_DemonHunter_Chakram 5
http://www.d3lexicon.com/affix/of-the-boomerang-6 Skill_DemonHunter_Chakram 6
http://www.d3lexicon.com/affix/of-the-boomerang-7 Skill_DemonHunter_Chakram 7
http://www.d3lexicon.com/affix/of-the-boomerang-8 Skill_DemonHunter_Chakram 8
http://www.d3lexicon.com/affix/of-splinters Skill_DemonHunter_ClusterArrow 1
http://www.d3lexicon.com/affix/of-splinters-2 Skill_DemonHunter_ClusterArrow 2
http://www.d3lexicon.com/affix/of-splinters-3 Skill_DemonHunter_ClusterArrow 3
http://www.d3lexicon.com/affix/of-splinters-4 Skill_DemonHunter_ClusterArrow 4
http://www.d3lexicon.com/affix/of-splinters-5 Skill_DemonHunter_ClusterArrow 5
http://www.d3lexicon.com/affix/of-splinters-6 Skill_DemonHunter_ClusterArrow 6
http://www.d3lexicon.com/affix/of-splinters-7 Skill_DemonHunter_ClusterArrow 7
http://www.d3lexicon.com/affix/of-splinters-8 Skill_DemonHunter_ClusterArrow 8
http://www.d3lexicon.com/affix/of-blasting Skill_DemonHunter_ElementalArrow 1
http://www.d3lexicon.com/affix/of-blasting-2 Skill_DemonHunter_ElementalArrow 2
http://www.d3lexicon.com/affix/of-blasting-3 Skill_DemonHunter_ElementalArrow 3
http://www.d3lexicon.com/affix/of-blasting-4 Skill_DemonHunter_ElementalArrow 4
http://www.d3lexicon.com/affix/of-blasting-5 Skill_DemonHunter_ElementalArrow 5
http://www.d3lexicon.com/affix/of-blasting-6 Skill_DemonHunter_ElementalArrow 6
http://www.d3lexicon.com/affix/of-blasting-7 Skill_DemonHunter_ElementalArrow 7
http://www.d3lexicon.com/affix/of-blasting-8 Skill_DemonHunter_ElementalArrow 8
http://www.d3lexicon.com/affix/of-binding Skill_DemonHunter_EntanglingShot 1
http://www.d3lexicon.com/affix/of-binding-2 Skill_DemonHunter_EntanglingShot 2
http://www.d3lexicon.com/affix/of-binding-3 Skill_DemonHunter_EntanglingShot 3
http://www.d3lexicon.com/affix/of-binding-4 Skill_DemonHunter_EntanglingShot 4
http://www.d3lexicon.com/affix/of-binding-5 Skill_DemonHunter_EntanglingShot 5
http://www.d3lexicon.com/affix/of-binding-6 Skill_DemonHunter_EntanglingShot 6
http://www.d3lexicon.com/affix/of-binding-7 Skill_DemonHunter_EntanglingShot 7
http://www.d3lexicon.com/affix/of-binding-8 Skill_DemonHunter_EntanglingShot 8
http://www.d3lexicon.com/affix/of-suppression Skill_DemonHunter_EvasiveFire 1
http://www.d3lexicon.com/affix/of-suppression-2 Skill_DemonHunter_EvasiveFire 2
http://www.d3lexicon.com/affix/of-suppression-3 Skill_DemonHunter_EvasiveFire 3
http://www.d3lexicon.com/affix/of-suppression-4 Skill_DemonHunter_EvasiveFire 4
http://www.d3lexicon.com/affix/of-suppression-5 Skill_DemonHunter_EvasiveFire 5
http://www.d3lexicon.com/affix/of-suppression-6 Skill_DemonHunter_EvasiveFire 6
http://www.d3lexicon.com/affix/of-suppression-7 Skill_DemonHunter_EvasiveFire 7
http://www.d3lexicon.com/affix/of-suppression-8 Skill_DemonHunter_EvasiveFire 8
http://www.d3lexicon.com/affix/of-the-grenadier Skill_DemonHunter_Grenades 1
http://www.d3lexicon.com/affix/of-the-grenadier-2 Skill_DemonHunter_Grenades 2
http://www.d3lexicon.com/affix/of-the-grenadier-3 Skill_DemonHunter_Grenades 3
http://www.d3lexicon.com/affix/of-the-grenadier-4 Skill_DemonHunter_Grenades 4
http://www.d3lexicon.com/affix/of-the-grenadier-5 Skill_DemonHunter_Grenades 5
http://www.d3lexicon.com/affix/of-the-grenadier-6 Skill_DemonHunter_Grenades 6
http://www.d3lexicon.com/affix/of-the-grenadier-7 Skill_DemonHunter_Grenades 7
http://www.d3lexicon.com/affix/of-the-grenadier-8 Skill_DemonHunter_Grenades 8
http://www.d3lexicon.com/affix/of-the-predator Skill_DemonHunter_HungeringArrow 1
http://www.d3lexicon.com/affix/of-the-predator-2 Skill_DemonHunter_HungeringArrow 2
http://www.d3lexicon.com/affix/of-the-predator-3 Skill_DemonHunter_HungeringArrow 3
http://www.d3lexicon.com/affix/of-the-predator-4 Skill_DemonHunter_HungeringArrow 4
http://www.d3lexicon.com/affix/of-the-predator-5 Skill_DemonHunter_HungeringArrow 5
http://www.d3lexicon.com/affix/of-the-predator-6 Skill_DemonHunter_HungeringArrow 6
http://www.d3lexicon.com/affix/of-the-predator-7 Skill_DemonHunter_HungeringArrow 7
http://www.d3lexicon.com/affix/of-the-predator-8 Skill_DemonHunter_HungeringArrow 8
http://www.d3lexicon.com/affix/of-razors-2 Skill_DemonHunter_Impale 1
http://www.d3lexicon.com/affix/of-razors-3 Skill_DemonHunter_Impale 2
http://www.d3lexicon.com/affix/of-razors-4 Skill_DemonHunter_Impale 3
http://www.d3lexicon.com/affix/of-razors-5 Skill_DemonHunter_Impale 4
http://www.d3lexicon.com/affix/of-razors-6 Skill_DemonHunter_Impale 5
http://www.d3lexicon.com/affix/of-razors-7 Skill_DemonHunter_Impale 6
http://www.d3lexicon.com/affix/of-razors-8 Skill_DemonHunter_Impale 7
http://www.d3lexicon.com/affix/of-razors-9 Skill_DemonHunter_Impale 8
http://www.d3lexicon.com/affix/of-volleys Skill_DemonHunter_Multishot 1
http://www.d3lexicon.com/affix/of-volleys-2 Skill_DemonHunter_Multishot 2
http://www.d3lexicon.com/affix/of-volleys-3 Skill_DemonHunter_Multishot 3
http://www.d3lexicon.com/affix/of-volleys-4 Skill_DemonHunter_Multishot 4
http://www.d3lexicon.com/affix/of-volleys-5 Skill_DemonHunter_Multishot 5
http://www.d3lexicon.com/affix/of-volleys-6 Skill_DemonHunter_Multishot 6
http://www.d3lexicon.com/affix/of-volleys-7 Skill_DemonHunter_Multishot 7
http://www.d3lexicon.com/affix/of-volleys-8 Skill_DemonHunter_Multishot 8
http://www.d3lexicon.com/affix/of-salvos Skill_DemonHunter_RapidFire 1
http://www.d3lexicon.com/affix/of-salvos-2 Skill_DemonHunter_RapidFire 2
http://www.d3lexicon.com/affix/of-salvos-3 Skill_DemonHunter_RapidFire 3
http://www.d3lexicon.com/affix/of-salvos-4 Skill_DemonHunter_RapidFire 4
http://www.d3lexicon.com/affix/of-salvos-5 Skill_DemonHunter_RapidFire 5
http://www.d3lexicon.com/affix/of-salvos-6 Skill_DemonHunter_RapidFire 6
http://www.d3lexicon.com/affix/of-salvos-7 Skill_DemonHunter_RapidFire 7
http://www.d3lexicon.com/affix/of-salvos-8 Skill_DemonHunter_RapidFire 8
http://www.d3lexicon.com/affix/of-spines Skill_DemonHunter_SpikeTrap 1
http://www.d3lexicon.com/affix/of-spines-2 Skill_DemonHunter_SpikeTrap 2
http://www.d3lexicon.com/affix/of-spines-3 Skill_DemonHunter_SpikeTrap 3
http://www.d3lexicon.com/affix/of-spines-4 Skill_DemonHunter_SpikeTrap 4
http://www.d3lexicon.com/affix/of-spines-5 Skill_DemonHunter_SpikeTrap 5
http://www.d3lexicon.com/affix/of-spines-6 Skill_DemonHunter_SpikeTrap 6
http://www.d3lexicon.com/affix/of-spines-7 Skill_DemonHunter_SpikeTrap 7
http://www.d3lexicon.com/affix/of-spines-8 Skill_DemonHunter_SpikeTrap 8
http://www.d3lexicon.com/affix/of-prowess Skill_DemonHunter_Strafe 1
http://www.d3lexicon.com/affix/of-prowess-2 Skill_DemonHunter_Strafe 2
http://www.d3lexicon.com/affix/of-prowess-3 Skill_DemonHunter_Strafe 3
http://www.d3lexicon.com/affix/of-prowess-4 Skill_DemonHunter_Strafe 4
http://www.d3lexicon.com/affix/of-prowess-5 Skill_DemonHunter_Strafe 5
http://www.d3lexicon.com/affix/of-prowess-6 Skill_DemonHunter_Strafe 6
http://www.d3lexicon.com/affix/of-prowess-7 Skill_DemonHunter_Strafe 7
http://www.d3lexicon.com/affix/of-prowess-8 Skill_DemonHunter_Strafe 8
http://www.d3lexicon.com/affix/of-breaking Skill_Monk_CripplingWave 1
http://www.d3lexicon.com/affix/of-breaking-2 Skill_Monk_CripplingWave 2
http://www.d3lexicon.com/affix/of-breaking-3 Skill_Monk_CripplingWave 3
http://www.d3lexicon.com/affix/of-breaking-4 Skill_Monk_CripplingWave 4
http://www.d3lexicon.com/affix/of-breaking-5 Skill_Monk_CripplingWave 5
http://www.d3lexicon.com/affix/of-breaking-6 Skill_Monk_CripplingWave 6
http://www.d3lexicon.com/affix/of-breaking-7 Skill_Monk_CripplingWave 7
http://www.d3lexicon.com/affix/of-breaking-8 Skill_Monk_CripplingWave 8
http://www.d3lexicon.com/affix/of-the-hurricane Skill_Monk_CycloneStrike 1
http://www.d3lexicon.com/affix/of-the-hurricane-2 Skill_Monk_CycloneStrike 2
http://www.d3lexicon.com/affix/of-the-hurricane-3 Skill_Monk_CycloneStrike 3
http://www.d3lexicon.com/affix/of-the-hurricane-4 Skill_Monk_CycloneStrike 4
http://www.d3lexicon.com/affix/of-the-hurricane-5 Skill_Monk_CycloneStrike 5
http://www.d3lexicon.com/affix/of-the-hurricane-6 Skill_Monk_CycloneStrike 6
http://www.d3lexicon.com/affix/of-the-hurricane-7 Skill_Monk_CycloneStrike 7
http://www.d3lexicon.com/affix/of-the-hurricane-8 Skill_Monk_CycloneStrike 8
http://www.d3lexicon.com/affix/of-lunging Skill_Monk_DeadlyReach 1
http://www.d3lexicon.com/affix/of-lunging-2 Skill_Monk_DeadlyReach 2
http://www.d3lexicon.com/affix/of-lunging-3 Skill_Monk_DeadlyReach 3
http://www.d3lexicon.com/affix/of-lunging-4 Skill_Monk_DeadlyReach 4
http://www.d3lexicon.com/affix/of-lunging-5 Skill_Monk_DeadlyReach 5
http://www.d3lexicon.com/affix/of-lunging-6 Skill_Monk_DeadlyReach 6
http://www.d3lexicon.com/affix/of-lunging-7 Skill_Monk_DeadlyReach 7
http://www.d3lexicon.com/affix/of-lunging-8 Skill_Monk_DeadlyReach 8
http://www.d3lexicon.com/affix/of-bursting Skill_Monk_ExplodingPalm 1
http://www.d3lexicon.com/affix/of-bursting-2 Skill_Monk_ExplodingPalm 2
http://www.d3lexicon.com/affix/of-bursting-3 Skill_Monk_ExplodingPalm 3
http://www.d3lexicon.com/affix/of-bursting-4 Skill_Monk_ExplodingPalm 4
http://www.d3lexicon.com/affix/of-bursting-5 Skill_Monk_ExplodingPalm 5
http://www.d3lexicon.com/affix/of-bursting-6 Skill_Monk_ExplodingPalm 6
http://www.d3lexicon.com/affix/of-bursting-7 Skill_Monk_ExplodingPalm 7
http://www.d3lexicon.com/affix/of-bursting-8 Skill_Monk_ExplodingPalm 8
http://www.d3lexicon.com/affix/of-the-monsoon Skill_Monk_FistsofThunder 1
http://www.d3lexicon.com/affix/of-the-monsoon-2 Skill_Monk_FistsofThunder 2
http://www.d3lexicon.com/affix/of-the-monsoon-3 Skill_Monk_FistsofThunder 3
http://www.d3lexicon.com/affix/of-the-monsoon-4 Skill_Monk_FistsofThunder 4
http://www.d3lexicon.com/affix/of-the-monsoon-5 Skill_Monk_FistsofThunder 5
http://www.d3lexicon.com/affix/of-the-monsoon-6 Skill_Monk_FistsofThunder 6
http://www.d3lexicon.com/affix/of-the-monsoon-7 Skill_Monk_FistsofThunder 7
http://www.d3lexicon.com/affix/of-the-monsoon-8 Skill_Monk_FistsofThunder 8
http://www.d3lexicon.com/affix/of-the-scorpion Skill_Monk_LashingTailKick 1
http://www.d3lexicon.com/affix/of-the-scorpion-2 Skill_Monk_LashingTailKick 2
http://www.d3lexicon.com/affix/of-the-scorpion-3 Skill_Monk_LashingTailKick 3
http://www.d3lexicon.com/affix/of-the-scorpion-4 Skill_Monk_LashingTailKick 4
http://www.d3lexicon.com/affix/of-the-scorpion-5 Skill_Monk_LashingTailKick 5
http://www.d3lexicon.com/affix/of-the-scorpion-6 Skill_Monk_LashingTailKick 6
http://www.d3lexicon.com/affix/of-the-scorpion-7 Skill_Monk_LashingTailKick 7
http://www.d3lexicon.com/affix/of-the-scorpion-8 Skill_Monk_LashingTailKick 8
http://www.d3lexicon.com/affix/of-the-wind Skill_Monk_SweepingWind 1
http://www.d3lexicon.com/affix/of-the-wind-2 Skill_Monk_SweepingWind 2
http://www.d3lexicon.com/affix/of-the-wind-3 Skill_Monk_SweepingWind 3
http://www.d3lexicon.com/affix/of-the-wind-4 Skill_Monk_SweepingWind 4
http://www.d3lexicon.com/affix/of-the-wind-5 Skill_Monk_SweepingWind 5
http://www.d3lexicon.com/affix/of-the-wind-6 Skill_Monk_SweepingWind 6
http://www.d3lexicon.com/affix/of-the-wind-7 Skill_Monk_SweepingWind 7
http://www.d3lexicon.com/affix/of-the-wind-8 Skill_Monk_SweepingWind 8
http://www.d3lexicon.com/affix/of-reflex Skill_Monk_TempestRush 1
http://www.d3lexicon.com/affix/of-reflex-2 Skill_Monk_TempestRush 2
http://www.d3lexicon.com/affix/of-reflex-3 Skill_Monk_TempestRush 3
http://www.d3lexicon.com/affix/of-reflex-4 Skill_Monk_TempestRush 4
http://www.d3lexicon.com/affix/of-reflex-5 Skill_Monk_TempestRush 5
http://www.d3lexicon.com/affix/of-reflex-6 Skill_Monk_TempestRush 6
http://www.d3lexicon.com/affix/of-reflex-7 Skill_Monk_TempestRush 7
http://www.d3lexicon.com/affix/of-reflex-8 Skill_Monk_TempestRush 8
http://www.d3lexicon.com/affix/of-radiance Skill_Monk_WaveofLight 1
http://www.d3lexicon.com/affix/of-radiance-2 Skill_Monk_WaveofLight 2
http://www.d3lexicon.com/affix/of-radiance-3 Skill_Monk_WaveofLight 3
http://www.d3lexicon.com/affix/of-radiance-4 Skill_Monk_WaveofLight 4
http://www.d3lexicon.com/affix/of-radiance-5 Skill_Monk_WaveofLight 5
http://www.d3lexicon.com/affix/of-radiance-6 Skill_Monk_WaveofLight 6
http://www.d3lexicon.com/affix/of-radiance-7 Skill_Monk_WaveofLight 7
http://www.d3lexicon.com/affix/of-radiance-8 Skill_Monk_WaveofLight 8
http://www.d3lexicon.com/affix/of-pummeling Skill_Monk_Wayof100Fists 1
http://www.d3lexicon.com/affix/of-pummeling-2 Skill_Monk_Wayof100Fists 2
http://www.d3lexicon.com/affix/of-pummeling-3 Skill_Monk_Wayof100Fists 3
http://www.d3lexicon.com/affix/of-pummeling-4 Skill_Monk_Wayof100Fists 4
http://www.d3lexicon.com/affix/of-pummeling-5 Skill_Monk_Wayof100Fists 5
http://www.d3lexicon.com/affix/of-pummeling-6 Skill_Monk_Wayof100Fists 6
http://www.d3lexicon.com/affix/of-pummeling-7 Skill_Monk_Wayof100Fists 7
http://www.d3lexicon.com/affix/of-pummeling-8 Skill_Monk_Wayof100Fists 8
http://www.d3lexicon.com/affix/of-corrosion Skill_WitchDoctor_AcidCloud 1
http://www.d3lexicon.com/affix/of-corrosion-2 Skill_WitchDoctor_AcidCloud 2
http://www.d3lexicon.com/affix/of-corrosion-3 Skill_WitchDoctor_AcidCloud 3
http://www.d3lexicon.com/affix/of-corrosion-4 Skill_WitchDoctor_AcidCloud 4
http://www.d3lexicon.com/affix/of-corrosion-5 Skill_WitchDoctor_AcidCloud 5
http://www.d3lexicon.com/affix/of-corrosion-6 Skill_WitchDoctor_AcidCloud 6
http://www.d3lexicon.com/affix/of-corrosion-7 Skill_WitchDoctor_AcidCloud 7
http://www.d3lexicon.com/affix/of-corrosion-8 Skill_WitchDoctor_AcidCloud 8
http://www.d3lexicon.com/affix/of-the-black-widow Skill_WitchDoctor_CorpseSpiders 1
http://www.d3lexicon.com/affix/of-the-black-widow-2 Skill_WitchDoctor_CorpseSpiders 2
http://www.d3lexicon.com/affix/of-the-black-widow-3 Skill_WitchDoctor_CorpseSpiders 3
http://www.d3lexicon.com/affix/of-the-black-widow-4 Skill_WitchDoctor_CorpseSpiders 4
http://www.d3lexicon.com/affix/of-the-black-widow-5 Skill_WitchDoctor_CorpseSpiders 5
http://www.d3lexicon.com/affix/of-the-black-widow-6 Skill_WitchDoctor_CorpseSpiders 6
http://www.d3lexicon.com/affix/of-the-black-widow-7 Skill_WitchDoctor_CorpseSpiders 7
http://www.d3lexicon.com/affix/of-the-black-widow-8 Skill_WitchDoctor_CorpseSpiders 8
http://www.d3lexicon.com/affix/of-the-deep Skill_WitchDoctor_Firebats 1
http://www.d3lexicon.com/affix/of-the-deep-2 Skill_WitchDoctor_Firebats 2
http://www.d3lexicon.com/affix/of-the-deep-3 Skill_WitchDoctor_Firebats 3
http://www.d3lexicon.com/affix/of-the-deep-4 Skill_WitchDoctor_Firebats 4
http://www.d3lexicon.com/affix/of-the-deep-5 Skill_WitchDoctor_Firebats 5
http://www.d3lexicon.com/affix/of-the-deep-6 Skill_WitchDoctor_Firebats 6
http://www.d3lexicon.com/affix/of-the-deep-7 Skill_WitchDoctor_Firebats 7
http://www.d3lexicon.com/affix/of-the-deep-8 Skill_WitchDoctor_Firebats 8
http://www.d3lexicon.com/affix/of-blazing Skill_WitchDoctor_FireBomb 1
http://www.d3lexicon.com/affix/of-blazing-2 Skill_WitchDoctor_FireBomb 2
http://www.d3lexicon.com/affix/of-blazing-3 Skill_WitchDoctor_FireBomb 3
http://www.d3lexicon.com/affix/of-blazing-4 Skill_WitchDoctor_FireBomb 4
http://www.d3lexicon.com/affix/of-blazing-5 Skill_WitchDoctor_FireBomb 5
http://www.d3lexicon.com/affix/of-blazing-6 Skill_WitchDoctor_FireBomb 6
http://www.d3lexicon.com/affix/of-blazing-7 Skill_WitchDoctor_FireBomb 7
http://www.d3lexicon.com/affix/of-blazing-8 Skill_WitchDoctor_FireBomb 8
http://www.d3lexicon.com/affix/of-the-wraith Skill_WitchDoctor_Haunt 1
http://www.d3lexicon.com/affix/of-the-wraith-2 Skill_WitchDoctor_Haunt 2
http://www.d3lexicon.com/affix/of-the-wraith-3 Skill_WitchDoctor_Haunt 3
http://www.d3lexicon.com/affix/of-the-wraith-4 Skill_WitchDoctor_Haunt 4
http://www.d3lexicon.com/affix/of-the-wraith-5 Skill_WitchDoctor_Haunt 5
http://www.d3lexicon.com/affix/of-the-wraith-6 Skill_WitchDoctor_Haunt 6
http://www.d3lexicon.com/affix/of-the-wraith-7 Skill_WitchDoctor_Haunt 7
http://www.d3lexicon.com/affix/of-the-wraith-8 Skill_WitchDoctor_Haunt 8
http://www.d3lexicon.com/affix/of-pestilence Skill_WitchDoctor_LocustSwarm 1
http://www.d3lexicon.com/affix/of-pestilence-2 Skill_WitchDoctor_LocustSwarm 2
http://www.d3lexicon.com/affix/of-pestilence-3 Skill_WitchDoctor_LocustSwarm 3
http://www.d3lexicon.com/affix/of-pestilence-4 Skill_WitchDoctor_LocustSwarm 4
http://www.d3lexicon.com/affix/of-pestilence-5 Skill_WitchDoctor_LocustSwarm 5
http://www.d3lexicon.com/affix/of-pestilence-6 Skill_WitchDoctor_LocustSwarm 6
http://www.d3lexicon.com/affix/of-pestilence-7 Skill_WitchDoctor_LocustSwarm 7
http://www.d3lexicon.com/affix/of-pestilence-8 Skill_WitchDoctor_LocustSwarm 8
http://www.d3lexicon.com/affix/of-the-jungle Skill_WitchDoctor_PlagueofToads 1
http://www.d3lexicon.com/affix/of-the-jungle-2 Skill_WitchDoctor_PlagueofToads 2
http://www.d3lexicon.com/affix/of-the-jungle-3 Skill_WitchDoctor_PlagueofToads 3
http://www.d3lexicon.com/affix/of-the-jungle-4 Skill_WitchDoctor_PlagueofToads 4
http://www.d3lexicon.com/affix/of-the-jungle-5 Skill_WitchDoctor_PlagueofToads 5
http://www.d3lexicon.com/affix/of-the-jungle-6 Skill_WitchDoctor_PlagueofToads 6
http://www.d3lexicon.com/affix/of-the-jungle-7 Skill_WitchDoctor_PlagueofToads 7
http://www.d3lexicon.com/affix/of-the-jungle-8 Skill_WitchDoctor_PlagueofToads 8
http://www.d3lexicon.com/affix/of-stinging Skill_WitchDoctor_PoisonDart 1
http://www.d3lexicon.com/affix/of-stinging-2 Skill_WitchDoctor_PoisonDart 2
http://www.d3lexicon.com/affix/of-stinging-3 Skill_WitchDoctor_PoisonDart 3
http://www.d3lexicon.com/affix/of-stinging-4 Skill_WitchDoctor_PoisonDart 4
http://www.d3lexicon.com/affix/of-stinging-5 Skill_WitchDoctor_PoisonDart 5
http://www.d3lexicon.com/affix/of-stinging-6 Skill_WitchDoctor_PoisonDart 6
http://www.d3lexicon.com/affix/of-stinging-7 Skill_WitchDoctor_PoisonDart 7
http://www.d3lexicon.com/affix/of-stinging-8 Skill_WitchDoctor_PoisonDart 8
http://www.d3lexicon.com/affix/of-phantoms Skill_WitchDoctor_SpiritBarrage 1
http://www.d3lexicon.com/affix/of-phantoms-2 Skill_WitchDoctor_SpiritBarrage 2
http://www.d3lexicon.com/affix/of-phantoms-3 Skill_WitchDoctor_SpiritBarrage 3
http://www.d3lexicon.com/affix/of-phantoms-4 Skill_WitchDoctor_SpiritBarrage 4
http://www.d3lexicon.com/affix/of-phantoms-5 Skill_WitchDoctor_SpiritBarrage 5
http://www.d3lexicon.com/affix/of-phantoms-6 Skill_WitchDoctor_SpiritBarrage 6
http://www.d3lexicon.com/affix/of-phantoms-7 Skill_WitchDoctor_SpiritBarrage 7
http://www.d3lexicon.com/affix/of-phantoms-8 Skill_WitchDoctor_SpiritBarrage 8
http://www.d3lexicon.com/affix/of-the-lost Skill_WitchDoctor_WallofZombies 1
http://www.d3lexicon.com/affix/of-the-lost-2 Skill_WitchDoctor_WallofZombies 2
http://www.d3lexicon.com/affix/of-the-lost-3 Skill_WitchDoctor_WallofZombies 3
http://www.d3lexicon.com/affix/of-the-lost-4 Skill_WitchDoctor_WallofZombies 4
http://www.d3lexicon.com/affix/of-the-lost-5 Skill_WitchDoctor_WallofZombies 5
http://www.d3lexicon.com/affix/of-the-lost-6 Skill_WitchDoctor_WallofZombies 6
http://www.d3lexicon.com/affix/of-the-lost-7 Skill_WitchDoctor_WallofZombies 7
http://www.d3lexicon.com/affix/of-the-lost-8 Skill_WitchDoctor_WallofZombies 8
http://www.d3lexicon.com/affix/of-blind-rage Skill_WitchDoctor_ZombieCharger 1
http://www.d3lexicon.com/affix/of-blind-rage-2 Skill_WitchDoctor_ZombieCharger 2
http://www.d3lexicon.com/affix/of-blind-rage-3 Skill_WitchDoctor_ZombieCharger 3
http://www.d3lexicon.com/affix/of-blind-rage-4 Skill_WitchDoctor_ZombieCharger 4
http://www.d3lexicon.com/affix/of-blind-rage-5 Skill_WitchDoctor_ZombieCharger 5
http://www.d3lexicon.com/affix/of-blind-rage-6 Skill_WitchDoctor_ZombieCharger 6
http://www.d3lexicon.com/affix/of-blind-rage-7 Skill_WitchDoctor_ZombieCharger 7
http://www.d3lexicon.com/affix/of-blind-rage-8 Skill_WitchDoctor_ZombieCharger 8
http://www.d3lexicon.com/affix/of-domination Skill_WitchDoctor_ZombieDogs 1
http://www.d3lexicon.com/affix/of-domination-2 Skill_WitchDoctor_ZombieDogs 2
http://www.d3lexicon.com/affix/of-domination-3 Skill_WitchDoctor_ZombieDogs 3
http://www.d3lexicon.com/affix/of-domination-4 Skill_WitchDoctor_ZombieDogs 4
http://www.d3lexicon.com/affix/of-domination-5 Skill_WitchDoctor_ZombieDogs 5
http://www.d3lexicon.com/affix/of-domination-6 Skill_WitchDoctor_ZombieDogs 6
http://www.d3lexicon.com/affix/of-domination-7 Skill_WitchDoctor_ZombieDogs 7
http://www.d3lexicon.com/affix/of-domination-8 Skill_WitchDoctor_ZombieDogs 8
http://www.d3lexicon.com/affix/of-spheres Skill_Wizard_ArcaneOrb 1
http://www.d3lexicon.com/affix/of-spheres-2 Skill_Wizard_ArcaneOrb 2
http://www.d3lexicon.com/affix/of-spheres-3 Skill_Wizard_ArcaneOrb 3
http://www.d3lexicon.com/affix/of-spheres-4 Skill_Wizard_ArcaneOrb 4
http://www.d3lexicon.com/affix/of-spheres-5 Skill_Wizard_ArcaneOrb 5
http://www.d3lexicon.com/affix/of-spheres-6 Skill_Wizard_ArcaneOrb 6
http://www.d3lexicon.com/affix/of-spheres-7 Skill_Wizard_ArcaneOrb 7
http://www.d3lexicon.com/affix/of-spheres-8 Skill_Wizard_ArcaneOrb 8
http://www.d3lexicon.com/affix/of-shooting-stars Skill_Wizard_ArcaneTorrent 1
http://www.d3lexicon.com/affix/of-shooting-stars-2 Skill_Wizard_ArcaneTorrent 2
http://www.d3lexicon.com/affix/of-shooting-stars-3 Skill_Wizard_ArcaneTorrent 3
http://www.d3lexicon.com/affix/of-shooting-stars-4 Skill_Wizard_ArcaneTorrent 4
http://www.d3lexicon.com/affix/of-shooting-stars-5 Skill_Wizard_ArcaneTorrent 5
http://www.d3lexicon.com/affix/of-shooting-stars-6 Skill_Wizard_ArcaneTorrent 6
http://www.d3lexicon.com/affix/of-shooting-stars-7 Skill_Wizard_ArcaneTorrent 7
http://www.d3lexicon.com/affix/of-shooting-stars-8 Skill_Wizard_ArcaneTorrent 8
http://www.d3lexicon.com/affix/of-hail-13 Skill_Wizard_Blizzard 1
http://www.d3lexicon.com/affix/of-hail-14 Skill_Wizard_Blizzard 2
http://www.d3lexicon.com/affix/of-hail-15 Skill_Wizard_Blizzard 3
http://www.d3lexicon.com/affix/of-hail-16 Skill_Wizard_Blizzard 4
http://www.d3lexicon.com/affix/of-hail-17 Skill_Wizard_Blizzard 5
http://www.d3lexicon.com/affix/of-hail-18 Skill_Wizard_Blizzard 6
http://www.d3lexicon.com/affix/of-hail-19 Skill_Wizard_Blizzard 7
http://www.d3lexicon.com/affix/of-hail-20 Skill_Wizard_Blizzard 8
http://www.d3lexicon.com/affix/of-entropy Skill_Wizard_Disintegrate 1
http://www.d3lexicon.com/affix/of-entropy-2 Skill_Wizard_Disintegrate 2
http://www.d3lexicon.com/affix/of-entropy-3 Skill_Wizard_Disintegrate 3
http://www.d3lexicon.com/affix/of-entropy-4 Skill_Wizard_Disintegrate 4
http://www.d3lexicon.com/affix/of-entropy-5 Skill_Wizard_Disintegrate 5
http://www.d3lexicon.com/affix/of-entropy-6 Skill_Wizard_Disintegrate 6
http://www.d3lexicon.com/affix/of-entropy-7 Skill_Wizard_Disintegrate 7
http://www.d3lexicon.com/affix/of-entropy-8 Skill_Wizard_Disintegrate 8
http://www.d3lexicon.com/affix/of-striking-13 Skill_Wizard_Electrocute 1
http://www.d3lexicon.com/affix/of-striking-14 Skill_Wizard_Electrocute 2
http://www.d3lexicon.com/affix/of-striking-15 Skill_Wizard_Electrocute 3
http://www.d3lexicon.com/affix/of-striking-16 Skill_Wizard_Electrocute 4
http://www.d3lexicon.com/affix/of-striking-17 Skill_Wizard_Electrocute 5
http://www.d3lexicon.com/affix/of-striking-18 Skill_Wizard_Electrocute 6
http://www.d3lexicon.com/affix/of-striking-19 Skill_Wizard_Electrocute 7
http://www.d3lexicon.com/affix/of-striking-20 Skill_Wizard_Electrocute 8
http://www.d3lexicon.com/affix/of-wild-magic Skill_Wizard_EnergyTwister 1
http://www.d3lexicon.com/affix/of-wild-magic-2 Skill_Wizard_EnergyTwister 2
http://www.d3lexicon.com/affix/of-wild-magic-3 Skill_Wizard_EnergyTwister 3
http://www.d3lexicon.com/affix/of-wild-magic-4 Skill_Wizard_EnergyTwister 4
http://www.d3lexicon.com/affix/of-wild-magic-5 Skill_Wizard_EnergyTwister 5
http://www.d3lexicon.com/affix/of-wild-magic-6 Skill_Wizard_EnergyTwister 6
http://www.d3lexicon.com/affix/of-wild-magic-7 Skill_Wizard_EnergyTwister 7
http://www.d3lexicon.com/affix/of-wild-magic-8 Skill_Wizard_EnergyTwister 8
http://www.d3lexicon.com/affix/of-detonation Skill_Wizard_ExplosiveBlast 1
http://www.d3lexicon.com/affix/of-detonation-2 Skill_Wizard_ExplosiveBlast 2
http://www.d3lexicon.com/affix/of-detonation-3 Skill_Wizard_ExplosiveBlast 3
http://www.d3lexicon.com/affix/of-detonation-4 Skill_Wizard_ExplosiveBlast 4
http://www.d3lexicon.com/affix/of-detonation-5 Skill_Wizard_ExplosiveBlast 5
http://www.d3lexicon.com/affix/of-detonation-6 Skill_Wizard_ExplosiveBlast 6
http://www.d3lexicon.com/affix/of-detonation-7 Skill_Wizard_ExplosiveBlast 7
http://www.d3lexicon.com/affix/of-detonation-8 Skill_Wizard_ExplosiveBlast 8
http://www.d3lexicon.com/affix/of-the-myriad Skill_Wizard_Hydra 1
http://www.d3lexicon.com/affix/of-the-myriad-2 Skill_Wizard_Hydra 2
http://www.d3lexicon.com/affix/of-the-myriad-3 Skill_Wizard_Hydra 3
http://www.d3lexicon.com/affix/of-the-myriad-4 Skill_Wizard_Hydra 4
http://www.d3lexicon.com/affix/of-the-myriad-5 Skill_Wizard_Hydra 5
http://www.d3lexicon.com/affix/of-the-myriad-6 Skill_Wizard_Hydra 6
http://www.d3lexicon.com/affix/of-the-myriad-7 Skill_Wizard_Hydra 7
http://www.d3lexicon.com/affix/of-the-myriad-8 Skill_Wizard_Hydra 8
http://www.d3lexicon.com/affix/of-evocation Skill_Wizard_MagicMissile 1
http://www.d3lexicon.com/affix/of-evocation-2 Skill_Wizard_MagicMissile 2
http://www.d3lexicon.com/affix/of-evocation-3 Skill_Wizard_MagicMissile 3
http://www.d3lexicon.com/affix/of-evocation-4 Skill_Wizard_MagicMissile 4
http://www.d3lexicon.com/affix/of-evocation-5 Skill_Wizard_MagicMissile 5
http://www.d3lexicon.com/affix/of-evocation-6 Skill_Wizard_MagicMissile 6
http://www.d3lexicon.com/affix/of-evocation-7 Skill_Wizard_MagicMissile 7
http://www.d3lexicon.com/affix/of-evocation-8 Skill_Wizard_MagicMissile 8
http://www.d3lexicon.com/affix/of-comets Skill_Wizard_Meteor 1
http://www.d3lexicon.com/affix/of-comets-2 Skill_Wizard_Meteor 2
http://www.d3lexicon.com/affix/of-comets-3 Skill_Wizard_Meteor 3
http://www.d3lexicon.com/affix/of-comets-4 Skill_Wizard_Meteor 4
http://www.d3lexicon.com/affix/of-comets-5 Skill_Wizard_Meteor 5
http://www.d3lexicon.com/affix/of-comets-6 Skill_Wizard_Meteor 6
http://www.d3lexicon.com/affix/of-comets-7 Skill_Wizard_Meteor 7
http://www.d3lexicon.com/affix/of-comets-8 Skill_Wizard_Meteor 8
http://www.d3lexicon.com/affix/of-chill Skill_Wizard_RayofFrost 1
http://www.d3lexicon.com/affix/of-chill-2 Skill_Wizard_RayofFrost 2
http://www.d3lexicon.com/affix/of-chill-3 Skill_Wizard_RayofFrost 3
http://www.d3lexicon.com/affix/of-chill-4 Skill_Wizard_RayofFrost 4
http://www.d3lexicon.com/affix/of-chill-5 Skill_Wizard_RayofFrost 5
http://www.d3lexicon.com/affix/of-chill-6 Skill_Wizard_RayofFrost 6
http://www.d3lexicon.com/affix/of-chill-7 Skill_Wizard_RayofFrost 7
http://www.d3lexicon.com/affix/of-chill-8 Skill_Wizard_RayofFrost 8
http://www.d3lexicon.com/affix/of-ruin-10 Skill_Wizard_ShockPulse 1
http://www.d3lexicon.com/affix/of-ruin-11 Skill_Wizard_ShockPulse 2
http://www.d3lexicon.com/affix/of-ruin-12 Skill_Wizard_ShockPulse 3
http://www.d3lexicon.com/affix/of-ruin-13 Skill_Wizard_ShockPulse 4
http://www.d3lexicon.com/affix/of-ruin-14 Skill_Wizard_ShockPulse 5
http://www.d3lexicon.com/affix/of-ruin-15 Skill_Wizard_ShockPulse 6
http://www.d3lexicon.com/affix/of-ruin-16 Skill_Wizard_ShockPulse 7
http://www.d3lexicon.com/affix/of-ruin-17 Skill_Wizard_ShockPulse 8
http://www.d3lexicon.com/affix/of-slashing Skill_Wizard_SpectralBlade 1
http://www.d3lexicon.com/affix/of-slashing-2 Skill_Wizard_SpectralBlade 2
http://www.d3lexicon.com/affix/of-slashing-3 Skill_Wizard_SpectralBlade 3
http://www.d3lexicon.com/affix/of-slashing-4 Skill_Wizard_SpectralBlade 4
http://www.d3lexicon.com/affix/of-slashing-5 Skill_Wizard_SpectralBlade 5
http://www.d3lexicon.com/affix/of-slashing-6 Skill_Wizard_SpectralBlade 6
http://www.d3lexicon.com/affix/of-slashing-7 Skill_Wizard_SpectralBlade 7
http://www.d3lexicon.com/affix/of-slashing-8 Skill_Wizard_SpectralBlade 8
http://www.d3lexicon.com/affix/socketed-23 Sockets Amulet I
http://www.d3lexicon.com/affix/socketed-24 Sockets Amulet II
http://www.d3lexicon.com/affix/socketed-25 Sockets Amulet III
http://www.d3lexicon.com/affix/socketed-26 Sockets Amulet IV
http://www.d3lexicon.com/affix/socketed-27 Sockets Amulet V
http://www.d3lexicon.com/affix/socketed-38 Sockets Belt I
http://www.d3lexicon.com/affix/socketed-39 Sockets Belt II
http://www.d3lexicon.com/affix/socketed-40 Sockets Belt III
http://www.d3lexicon.com/affix/socketed-41 Sockets Belt IV
http://www.d3lexicon.com/affix/socketed-42 Sockets Belt V
http://www.d3lexicon.com/affix/socketed-43 Sockets Bracer I
http://www.d3lexicon.com/affix/socketed-44 Sockets Bracer II
http://www.d3lexicon.com/affix/socketed-45 Sockets Bracer III
http://www.d3lexicon.com/affix/socketed-46 Sockets Bracer IV
http://www.d3lexicon.com/affix/socketed-47 Sockets Bracer V
http://www.d3lexicon.com/affix/socketed-28 Sockets Chest I
http://www.d3lexicon.com/affix/socketed-29 Sockets Chest II
http://www.d3lexicon.com/affix/socketed-30 Sockets Chest III
http://www.d3lexicon.com/affix/socketed-31 Sockets Chest IV
http://www.d3lexicon.com/affix/socketed-32 Sockets Chest V
http://www.d3lexicon.com/affix/socketed-18 Sockets Helm I
http://www.d3lexicon.com/affix/socketed-19 Sockets Helm II
http://www.d3lexicon.com/affix/socketed-20 Sockets Helm III
http://www.d3lexicon.com/affix/socketed-21 Sockets Helm IV
http://www.d3lexicon.com/affix/socketed-22 Sockets Helm V
http://www.d3lexicon.com/affix/socketed Sockets I
http://www.d3lexicon.com/affix/socketed-2 Sockets II
http://www.d3lexicon.com/affix/socketed-3 Sockets III
http://www.d3lexicon.com/affix/socketed-4 Sockets IV
http://www.d3lexicon.com/affix/socketed-9 Sockets IX
http://www.d3lexicon.com/affix/socketed-33 Sockets Shield I
http://www.d3lexicon.com/affix/socketed-34 Sockets Shield II
http://www.d3lexicon.com/affix/socketed-35 Sockets Shield III
http://www.d3lexicon.com/affix/socketed-36 Sockets Shield IV
http://www.d3lexicon.com/affix/socketed-37 Sockets Shield V
http://www.d3lexicon.com/affix/socketed-5 Sockets V
http://www.d3lexicon.com/affix/socketed-6 Sockets VI
http://www.d3lexicon.com/affix/socketed-7 Sockets VII
http://www.d3lexicon.com/affix/socketed-8 Sockets VIII
http://www.d3lexicon.com/affix/socketed-10 Sockets X
http://www.d3lexicon.com/affix/socketed-11 Sockets XI
http://www.d3lexicon.com/affix/socketed-12 Sockets XII
http://www.d3lexicon.com/affix/socketed-13 Sockets XIII
http://www.d3lexicon.com/affix/socketed-14 Sockets XIV
http://www.d3lexicon.com/affix/socketed-15 Sockets XV
http://www.d3lexicon.com/affix/socketed-16 Sockets XVI
http://www.d3lexicon.com/affix/socketed-17 Sockets XVII
http://www.d3lexicon.com/affix/resonant SpiritHeals 1
http://www.d3lexicon.com/affix/resonant-2 SpiritHeals 2
http://www.d3lexicon.com/affix/resonant-3 SpiritHeals 3
http://www.d3lexicon.com/affix/rejuvenating SpiritHeals 4
http://www.d3lexicon.com/affix/rejuvenating-2 SpiritHeals 5
http://www.d3lexicon.com/affix/rejuvenating-3 SpiritHeals 6
http://www.d3lexicon.com/affix/harmonious SpiritHeals 7
http://www.d3lexicon.com/affix/harmonious-2 SpiritHeals 8
http://www.d3lexicon.com/affix/harmonious-3 SpiritHeals 9
http://www.d3lexicon.com/affix/exalted SpiritHeals 10
http://www.d3lexicon.com/affix/illuminating SpiritRegen 1
http://www.d3lexicon.com/affix/illuminating-2 SpiritRegen 2
http://www.d3lexicon.com/affix/illuminating-3 SpiritRegen 3
http://www.d3lexicon.com/affix/reborn SpiritRegen 4
http://www.d3lexicon.com/affix/reborn-2 SpiritRegen 5
http://www.d3lexicon.com/affix/reborn-3 SpiritRegen 6
http://www.d3lexicon.com/affix/awakening SpiritRegen 7
http://www.d3lexicon.com/affix/awakening-2 SpiritRegen 8
http://www.d3lexicon.com/affix/awakening-3 SpiritRegen 9
http://www.d3lexicon.com/affix/enlightening SpiritRegen 10
http://www.d3lexicon.com/affix/of-the-lion Str 1
http://www.d3lexicon.com/affix/str-1-secondary Str 1 Secondary
http://www.d3lexicon.com/affix/of-the-lion-2 Str 2
http://www.d3lexicon.com/affix/str-2-secondary Str 2 Secondary
http://www.d3lexicon.com/affix/of-the-lion-3 Str 3
http://www.d3lexicon.com/affix/str-3-secondary Str 3 Secondary
http://www.d3lexicon.com/affix/of-the-lion-4 Str 4
http://www.d3lexicon.com/affix/str-4-secondary Str 4 Secondary
http://www.d3lexicon.com/affix/of-invasion Str 5
http://www.d3lexicon.com/affix/str-5-secondary Str 5 Secondary
http://www.d3lexicon.com/affix/of-invasion-2 Str 6
http://www.d3lexicon.com/affix/str-6-secondary Str 6 Secondary
http://www.d3lexicon.com/affix/of-invasion-3 Str 7
http://www.d3lexicon.com/affix/str-7-secondary Str 7 Secondary
http://www.d3lexicon.com/affix/of-invasion-4 Str 8
http://www.d3lexicon.com/affix/str-8-secondary Str 8 Secondary
http://www.d3lexicon.com/affix/of-invasion-5 Str 9
http://www.d3lexicon.com/affix/str-9-secondary Str 9 Secondary
http://www.d3lexicon.com/affix/of-invasion-6 Str 10
http://www.d3lexicon.com/affix/str-10-secondary Str 10 Secondary
http://www.d3lexicon.com/affix/of-invasion-7 Str 11
http://www.d3lexicon.com/affix/str-11-secondary Str 11 Secondary
http://www.d3lexicon.com/affix/of-assault Str 12
http://www.d3lexicon.com/affix/str-12-secondary Str 12 Secondary
http://www.d3lexicon.com/affix/of-assault-2 Str 13
http://www.d3lexicon.com/affix/str-13-secondary Str 13 Secondary
http://www.d3lexicon.com/affix/of-assault-3 Str 14
http://www.d3lexicon.com/affix/str-14-secondary Str 14 Secondary
http://www.d3lexicon.com/affix/of-assault-4 Str 15
http://www.d3lexicon.com/affix/str-15-secondary Str 15 Secondary
http://www.d3lexicon.com/affix/of-assault-5 Str 16
http://www.d3lexicon.com/affix/str-16-secondary Str 16 Secondary
http://www.d3lexicon.com/affix/cruel StrDex I
http://www.d3lexicon.com/affix/cruel-2 StrDex II
http://www.d3lexicon.com/affix/cruel-3 StrDex III
http://www.d3lexicon.com/affix/str-dex-iii-secondary StrDex III Secondary
http://www.d3lexicon.com/affix/str-dex-ii-secondary StrDex II Secondary
http://www.d3lexicon.com/affix/str-dex-i-secondary StrDex I Secondary
http://www.d3lexicon.com/affix/cruel-4 StrDex IV
http://www.d3lexicon.com/affix/str-dex-iv-secondary StrDex IV Secondary
http://www.d3lexicon.com/affix/vicious StrDex IX
http://www.d3lexicon.com/affix/str-dex-ix-secondary StrDex IX Secondary
http://www.d3lexicon.com/affix/severe StrDex V
http://www.d3lexicon.com/affix/severe-2 StrDex VI
http://www.d3lexicon.com/affix/severe-3 StrDex VII
http://www.d3lexicon.com/affix/severe-4 StrDex VIII
http://www.d3lexicon.com/affix/str-dex-viii-secondary StrDex VIII Secondary
http://www.d3lexicon.com/affix/str-dex-vii-secondary StrDex VII Secondary
http://www.d3lexicon.com/affix/str-dex-vi-secondary StrDex VI Secondary
http://www.d3lexicon.com/affix/str-dex-v-secondary StrDex V Secondary
http://www.d3lexicon.com/affix/vicious-2 StrDex X
http://www.d3lexicon.com/affix/vicious-3 StrDex XI
http://www.d3lexicon.com/affix/murderous StrDex XII
http://www.d3lexicon.com/affix/str-dex-xii-secondary StrDex XII Secondary
http://www.d3lexicon.com/affix/str-dex-xi-secondary StrDex XI Secondary
http://www.d3lexicon.com/affix/str-dex-x-secondary StrDex X Secondary
http://www.d3lexicon.com/affix/dueling StrInt I
http://www.d3lexicon.com/affix/dueling-2 StrInt II
http://www.d3lexicon.com/affix/dueling-3 StrInt III
http://www.d3lexicon.com/affix/str-int-iii-secondary StrInt III Secondary
http://www.d3lexicon.com/affix/str-int-ii-secondary StrInt II Secondary
http://www.d3lexicon.com/affix/str-int-i-secondary StrInt I Secondary
http://www.d3lexicon.com/affix/dueling-4 StrInt IV
http://www.d3lexicon.com/affix/str-int-iv-secondary StrInt IV Secondary
http://www.d3lexicon.com/affix/triumphant StrInt IX
http://www.d3lexicon.com/affix/str-int-ix-secondary StrInt IX Secondary
http://www.d3lexicon.com/affix/champion StrInt V
http://www.d3lexicon.com/affix/champion-2 StrInt VI
http://www.d3lexicon.com/affix/champion-3 StrInt VII
http://www.d3lexicon.com/affix/champion-4 StrInt VIII
http://www.d3lexicon.com/affix/str-int-viii-secondary StrInt VIII Secondary
http://www.d3lexicon.com/affix/str-int-vii-secondary StrInt VII Secondary
http://www.d3lexicon.com/affix/str-int-vi-secondary StrInt VI Secondary
http://www.d3lexicon.com/affix/str-int-v-secondary StrInt V Secondary
http://www.d3lexicon.com/affix/triumphant-2 StrInt X
http://www.d3lexicon.com/affix/triumphant-3 StrInt XI
http://www.d3lexicon.com/affix/paragon StrInt XII
http://www.d3lexicon.com/affix/str-int-xii-secondary StrInt XII Secondary
http://www.d3lexicon.com/affix/str-int-xi-secondary StrInt XI Secondary
http://www.d3lexicon.com/affix/str-int-x-secondary StrInt X Secondary
http://www.d3lexicon.com/affix/dauntless StrVit I
http://www.d3lexicon.com/affix/dauntless-2 StrVit II
http://www.d3lexicon.com/affix/dauntless-3 StrVit III
http://www.d3lexicon.com/affix/str-vit-iii-secondary StrVit III Secondary
http://www.d3lexicon.com/affix/str-vit-ii-secondary StrVit II Secondary
http://www.d3lexicon.com/affix/str-vit-i-secondary StrVit I Secondary
http://www.d3lexicon.com/affix/dauntless-4 StrVit IV
http://www.d3lexicon.com/affix/str-vit-iv-secondary StrVit IV Secondary
http://www.d3lexicon.com/affix/vigorous StrVit IX
http://www.d3lexicon.com/affix/str-vit-ix-secondary StrVit IX Secondary
http://www.d3lexicon.com/affix/relentless StrVit V
http://www.d3lexicon.com/affix/relentless-2 StrVit VI
http://www.d3lexicon.com/affix/relentless-3 StrVit VII
http://www.d3lexicon.com/affix/relentless-4 StrVit VIII
http://www.d3lexicon.com/affix/str-vit-viii-secondary StrVit VIII Secondary
http://www.d3lexicon.com/affix/str-vit-vii-secondary StrVit VII Secondary
http://www.d3lexicon.com/affix/str-vit-vi-secondary StrVit VI Secondary
http://www.d3lexicon.com/affix/str-vit-v-secondary StrVit V Secondary
http://www.d3lexicon.com/affix/vigorous-2 StrVit X
http://www.d3lexicon.com/affix/vigorous-3 StrVit XI
http://www.d3lexicon.com/affix/ruthless StrVit XII
http://www.d3lexicon.com/affix/str-vit-xii-secondary StrVit XII Secondary
http://www.d3lexicon.com/affix/str-vit-xi-secondary StrVit XI Secondary
http://www.d3lexicon.com/affix/str-vit-x-secondary StrVit X Secondary
http://www.d3lexicon.com/affix/superior Superior Armor
http://www.d3lexicon.com/affix/thick Superior Armor Def 1
http://www.d3lexicon.com/affix/thick-2 Superior Armor Def 2
http://www.d3lexicon.com/affix/thick-3 Superior Armor Def 3
http://www.d3lexicon.com/affix/thick-4 Superior Armor Def 4
http://www.d3lexicon.com/affix/thick-5 Superior Armor Def 5
http://www.d3lexicon.com/affix/thick-6 Superior Armor Def 6
http://www.d3lexicon.com/affix/fine Superior Weapon 1
http://www.d3lexicon.com/affix/fine-2 Superior Weapon 2
http://www.d3lexicon.com/affix/fine-3 Superior Weapon 3
http://www.d3lexicon.com/affix/fine-4 Superior Weapon 4
http://www.d3lexicon.com/affix/fine-5 Superior Weapon 5
http://www.d3lexicon.com/affix/fine-6 Superior Weapon 6
http://www.d3lexicon.com/affix/fine-7 Superior Weapon 7
http://www.d3lexicon.com/affix/solid Superior Weapon Crit Dmg 1
http://www.d3lexicon.com/affix/solid-2 Superior Weapon Crit Dmg 2
http://www.d3lexicon.com/affix/solid-3 Superior Weapon Crit Dmg 3
http://www.d3lexicon.com/affix/solid-4 Superior Weapon Crit Dmg 4
http://www.d3lexicon.com/affix/solid-5 Superior Weapon Crit Dmg 5
http://www.d3lexicon.com/affix/solid-6 Superior Weapon Crit Dmg 6
http://www.d3lexicon.com/affix/masterwork Superior Weapon MaxDmg 1
http://www.d3lexicon.com/affix/masterwork-2 Superior Weapon MaxDmg 2
http://www.d3lexicon.com/affix/masterwork-3 Superior Weapon MaxDmg 3
http://www.d3lexicon.com/affix/masterwork-4 Superior Weapon MaxDmg 4
http://www.d3lexicon.com/affix/masterwork-5 Superior Weapon MaxDmg 5
http://www.d3lexicon.com/affix/masterwork-6 Superior Weapon MaxDmg 6
http://www.d3lexicon.com/affix/exceptional Superior Weapon MinDmg 1
http://www.d3lexicon.com/affix/exceptional-2 Superior Weapon MinDmg 2
http://www.d3lexicon.com/affix/exceptional-3 Superior Weapon MinDmg 3
http://www.d3lexicon.com/affix/exceptional-4 Superior Weapon MinDmg 4
http://www.d3lexicon.com/affix/exceptional-5 Superior Weapon MinDmg 5
http://www.d3lexicon.com/affix/exceptional-6 Superior Weapon MinDmg 6
http://www.d3lexicon.com/affix/balanced Superior Weapon Speed 1
http://www.d3lexicon.com/affix/balanced-2 Superior Weapon Speed 2
http://www.d3lexicon.com/affix/balanced-3 Superior Weapon Speed 3
http://www.d3lexicon.com/affix/balanced-4 Superior Weapon Speed 4
http://www.d3lexicon.com/affix/balanced-5 Superior Weapon Speed 5
http://www.d3lexicon.com/affix/balanced-6 Superior Weapon Speed 6
http://www.d3lexicon.com/affix/of-thorns Thorns 1
http://www.d3lexicon.com/affix/thorns-1-secondary Thorns 1 Secondary
http://www.d3lexicon.com/affix/of-thorns-2 Thorns 2
http://www.d3lexicon.com/affix/thorns-2-secondary Thorns 2 Secondary
http://www.d3lexicon.com/affix/of-thorns-3 Thorns 3
http://www.d3lexicon.com/affix/thorns-3-secondary Thorns 3 Secondary
http://www.d3lexicon.com/affix/of-thorns-4 Thorns 4
http://www.d3lexicon.com/affix/thorns-4-secondary Thorns 4 Secondary
http://www.d3lexicon.com/affix/of-thorns-5 Thorns 5
http://www.d3lexicon.com/affix/thorns-5-secondary Thorns 5 Secondary
http://www.d3lexicon.com/affix/of-barbs Thorns 6
http://www.d3lexicon.com/affix/thorns-6-secondary Thorns 6 Secondary
http://www.d3lexicon.com/affix/of-barbs-2 Thorns 7
http://www.d3lexicon.com/affix/thorns-7-secondary Thorns 7 Secondary
http://www.d3lexicon.com/affix/of-barbs-3 Thorns 8
http://www.d3lexicon.com/affix/thorns-8-secondary Thorns 8 Secondary
http://www.d3lexicon.com/affix/of-barbs-4 Thorns 9
http://www.d3lexicon.com/affix/thorns-9-secondary Thorns 9 Secondary
http://www.d3lexicon.com/affix/of-barbs-5 Thorns 10
http://www.d3lexicon.com/affix/thorns-10-secondary Thorns 10 Secondary
http://www.d3lexicon.com/affix/of-spikes Thorns 11
http://www.d3lexicon.com/affix/thorns-11-secondary Thorns 11 Secondary
http://www.d3lexicon.com/affix/of-spikes-2 Thorns 12
http://www.d3lexicon.com/affix/thorns-12-secondary Thorns 12 Secondary
http://www.d3lexicon.com/affix/of-spikes-3 Thorns 13
http://www.d3lexicon.com/affix/thorns-13-secondary Thorns 13 Secondary
http://www.d3lexicon.com/affix/of-spikes-4 Thorns 14
http://www.d3lexicon.com/affix/thorns-14-secondary Thorns 14 Secondary
http://www.d3lexicon.com/affix/of-razors Thorns 15
http://www.d3lexicon.com/affix/thorns-15-secondary Thorns 15 Secondary
http://www.d3lexicon.com/affix/tribute-i Tribute I
http://www.d3lexicon.com/affix/of-unknown UnknownPrefix
http://www.d3lexicon.com/affix/of-unknown-suffix UnknownSuffix
http://www.d3lexicon.com/affix/vanish-i Vanish I
http://www.d3lexicon.com/affix/of-the-bear Vit 1
http://www.d3lexicon.com/affix/vit-1-secondary Vit 1 Secondary
http://www.d3lexicon.com/affix/of-the-bear-2 Vit 2
http://www.d3lexicon.com/affix/vit-2-secondary Vit 2 Secondary
http://www.d3lexicon.com/affix/of-the-bear-3 Vit 3
http://www.d3lexicon.com/affix/vit-3-secondary Vit 3 Secondary
http://www.d3lexicon.com/affix/of-the-bear-4 Vit 4
http://www.d3lexicon.com/affix/vit-4-secondary Vit 4 Secondary
http://www.d3lexicon.com/affix/of-the-bear-5 Vit 5
http://www.d3lexicon.com/affix/vit-5-secondary Vit 5 Secondary
http://www.d3lexicon.com/affix/of-fortitude Vit 6
http://www.d3lexicon.com/affix/vit-6-secondary Vit 6 Secondary
http://www.d3lexicon.com/affix/of-fortitude-2 Vit 7
http://www.d3lexicon.com/affix/vit-7-secondary Vit 7 Secondary
http://www.d3lexicon.com/affix/of-fortitude-3 Vit 8
http://www.d3lexicon.com/affix/vit-8-secondary Vit 8 Secondary
http://www.d3lexicon.com/affix/of-fortitude-4 Vit 9
http://www.d3lexicon.com/affix/vit-9-secondary Vit 9 Secondary
http://www.d3lexicon.com/affix/of-fortitude-5 Vit 10
http://www.d3lexicon.com/affix/vit-10-secondary Vit 10 Secondary
http://www.d3lexicon.com/affix/of-valor Vit 11
http://www.d3lexicon.com/affix/vit-11-secondary Vit 11 Secondary
http://www.d3lexicon.com/affix/of-valor-2 Vit 12
http://www.d3lexicon.com/affix/vit-12-secondary Vit 12 Secondary
http://www.d3lexicon.com/affix/of-valor-3 Vit 13
http://www.d3lexicon.com/affix/vit-13-secondary Vit 13 Secondary
http://www.d3lexicon.com/affix/of-valor-4 Vit 14
http://www.d3lexicon.com/affix/vit-14-secondary Vit 14 Secondary
http://www.d3lexicon.com/affix/of-valor-5 Vit 15
http://www.d3lexicon.com/affix/vit-15-secondary Vit 15 Secondary
http://www.d3lexicon.com/affix/of-glory Vit 16
http://www.d3lexicon.com/affix/vit-16-secondary Vit 16 Secondary
http://www.d3lexicon.com/affix/dazzling-5 WeaponHitBlind1h 1
http://www.d3lexicon.com/affix/dazzling-6 WeaponHitBlind1h 2
http://www.d3lexicon.com/affix/dazzling-7 WeaponHitBlind1h 3
http://www.d3lexicon.com/affix/dazzling-8 WeaponHitBlind1h 4
http://www.d3lexicon.com/affix/bewildering-5 WeaponHitBlind1h 5
http://www.d3lexicon.com/affix/bewildering-6 WeaponHitBlind1h 6
http://www.d3lexicon.com/affix/bewildering-7 WeaponHitBlind1h 7
http://www.d3lexicon.com/affix/bewildering-8 WeaponHitBlind1h 8
http://www.d3lexicon.com/affix/perplexing-4 WeaponHitBlind1h 9
http://www.d3lexicon.com/affix/perplexing-5 WeaponHitBlind1h 10
http://www.d3lexicon.com/affix/perplexing-6 WeaponHitBlind1h 11
http://www.d3lexicon.com/affix/hypnotic-2 WeaponHitBlind1h 12
http://www.d3lexicon.com/affix/dazzling-9 WeaponHitBlind2h 1
http://www.d3lexicon.com/affix/dazzling-10 WeaponHitBlind2h 2
http://www.d3lexicon.com/affix/dazzling-11 WeaponHitBlind2h 3
http://www.d3lexicon.com/affix/dazzling-12 WeaponHitBlind2h 4
http://www.d3lexicon.com/affix/bewildering-9 WeaponHitBlind2h 5
http://www.d3lexicon.com/affix/bewildering-10 WeaponHitBlind2h 6
http://www.d3lexicon.com/affix/bewildering-11 WeaponHitBlind2h 7
http://www.d3lexicon.com/affix/bewildering-12 WeaponHitBlind2h 8
http://www.d3lexicon.com/affix/perplexing-7 WeaponHitBlind2h 9
http://www.d3lexicon.com/affix/perplexing-8 WeaponHitBlind2h 10
http://www.d3lexicon.com/affix/perplexing-9 WeaponHitBlind2h 11
http://www.d3lexicon.com/affix/hypnotic-3 WeaponHitBlind2h 12
http://www.d3lexicon.com/affix/chilling-5 WeaponHitChill1h 1
http://www.d3lexicon.com/affix/chilling-6 WeaponHitChill1h 2
http://www.d3lexicon.com/affix/chilling-7 WeaponHitChill1h 3
http://www.d3lexicon.com/affix/chilling-8 WeaponHitChill1h 4
http://www.d3lexicon.com/affix/bleak-5 WeaponHitChill1h 5
http://www.d3lexicon.com/affix/bleak-6 WeaponHitChill1h 6
http://www.d3lexicon.com/affix/bleak-7 WeaponHitChill1h 7
http://www.d3lexicon.com/affix/bleak-8 WeaponHitChill1h 8
http://www.d3lexicon.com/affix/glacial-4 WeaponHitChill1h 9
http://www.d3lexicon.com/affix/glacial-5 WeaponHitChill1h 10
http://www.d3lexicon.com/affix/glacial-6 WeaponHitChill1h 11
http://www.d3lexicon.com/affix/hyperborean-2 WeaponHitChill1h 12
http://www.d3lexicon.com/affix/chilling-9 WeaponHitChill2h 1
http://www.d3lexicon.com/affix/chilling-10 WeaponHitChill2h 2
http://www.d3lexicon.com/affix/chilling-11 WeaponHitChill2h 3
http://www.d3lexicon.com/affix/chilling-12 WeaponHitChill2h 4
http://www.d3lexicon.com/affix/bleak-9 WeaponHitChill2h 5
http://www.d3lexicon.com/affix/bleak-10 WeaponHitChill2h 6
http://www.d3lexicon.com/affix/bleak-11 WeaponHitChill2h 7
http://www.d3lexicon.com/affix/bleak-12 WeaponHitChill2h 8
http://www.d3lexicon.com/affix/glacial-7 WeaponHitChill2h 9
http://www.d3lexicon.com/affix/glacial-8 WeaponHitChill2h 10
http://www.d3lexicon.com/affix/glacial-9 WeaponHitChill2h 11
http://www.d3lexicon.com/affix/hyperborean-3 WeaponHitChill2h 12
http://www.d3lexicon.com/affix/of-fright-5 WeaponHitFear1h 1
http://www.d3lexicon.com/affix/of-fright-6 WeaponHitFear1h 2
http://www.d3lexicon.com/affix/of-fright-7 WeaponHitFear1h 3
http://www.d3lexicon.com/affix/of-fright-8 WeaponHitFear1h 4
http://www.d3lexicon.com/affix/of-nightmares-5 WeaponHitFear1h 5
http://www.d3lexicon.com/affix/of-nightmares-6 WeaponHitFear1h 6
http://www.d3lexicon.com/affix/of-nightmares-7 WeaponHitFear1h 7
http://www.d3lexicon.com/affix/of-nightmares-8 WeaponHitFear1h 8
http://www.d3lexicon.com/affix/of-horror-4 WeaponHitFear1h 9
http://www.d3lexicon.com/affix/of-horror-5 WeaponHitFear1h 10
http://www.d3lexicon.com/affix/of-horror-6 WeaponHitFear1h 11
http://www.d3lexicon.com/affix/of-terror-2 WeaponHitFear1h 12
http://www.d3lexicon.com/affix/of-fright-9 WeaponHitFear2h 1
http://www.d3lexicon.com/affix/of-fright-10 WeaponHitFear2h 2
http://www.d3lexicon.com/affix/of-fright-11 WeaponHitFear2h 3
http://www.d3lexicon.com/affix/of-fright-12 WeaponHitFear2h 4
http://www.d3lexicon.com/affix/of-nightmares-9 WeaponHitFear2h 5
http://www.d3lexicon.com/affix/of-nightmares-10 WeaponHitFear2h 6
http://www.d3lexicon.com/affix/of-nightmares-11 WeaponHitFear2h 7
http://www.d3lexicon.com/affix/of-nightmares-12 WeaponHitFear2h 8
http://www.d3lexicon.com/affix/of-horror-7 WeaponHitFear2h 9
http://www.d3lexicon.com/affix/of-horror-8 WeaponHitFear2h 10
http://www.d3lexicon.com/affix/of-horror-9 WeaponHitFear2h 11
http://www.d3lexicon.com/affix/of-terror-3 WeaponHitFear2h 12
http://www.d3lexicon.com/affix/of-ice-5 WeaponHitFreeze1h 1
http://www.d3lexicon.com/affix/of-ice-6 WeaponHitFreeze1h 2
http://www.d3lexicon.com/affix/of-ice-7 WeaponHitFreeze1h 3
http://www.d3lexicon.com/affix/of-ice-8 WeaponHitFreeze1h 4
http://www.d3lexicon.com/affix/of-hail-5 WeaponHitFreeze1h 5
http://www.d3lexicon.com/affix/of-hail-6 WeaponHitFreeze1h 6
http://www.d3lexicon.com/affix/of-hail-7 WeaponHitFreeze1h 7
http://www.d3lexicon.com/affix/of-hail-8 WeaponHitFreeze1h 8
http://www.d3lexicon.com/affix/of-the-frozen-sea-4 WeaponHitFreeze1h 9
http://www.d3lexicon.com/affix/of-the-frozen-sea-5 WeaponHitFreeze1h 10
http://www.d3lexicon.com/affix/of-the-frozen-sea-6 WeaponHitFreeze1h 11
http://www.d3lexicon.com/affix/of-desolation-2 WeaponHitFreeze1h 12
http://www.d3lexicon.com/affix/of-ice-9 WeaponHitFreeze2h 1
http://www.d3lexicon.com/affix/of-ice-10 WeaponHitFreeze2h 2
http://www.d3lexicon.com/affix/of-ice-11 WeaponHitFreeze2h 3
http://www.d3lexicon.com/affix/of-ice-12 WeaponHitFreeze2h 4
http://www.d3lexicon.com/affix/of-hail-9 WeaponHitFreeze2h 5
http://www.d3lexicon.com/affix/of-hail-10 WeaponHitFreeze2h 6
http://www.d3lexicon.com/affix/of-hail-11 WeaponHitFreeze2h 7
http://www.d3lexicon.com/affix/of-hail-12 WeaponHitFreeze2h 8
http://www.d3lexicon.com/affix/of-the-frozen-sea-7 WeaponHitFreeze2h 9
http://www.d3lexicon.com/affix/of-the-frozen-sea-8 WeaponHitFreeze2h 10
http://www.d3lexicon.com/affix/of-the-frozen-sea-9 WeaponHitFreeze2h 11
http://www.d3lexicon.com/affix/of-desolation-3 WeaponHitFreeze2h 12
http://www.d3lexicon.com/affix/of-stagnation-5 WeaponHitImmobilize1h 1
http://www.d3lexicon.com/affix/of-stagnation-6 WeaponHitImmobilize1h 2
http://www.d3lexicon.com/affix/of-stagnation-7 WeaponHitImmobilize1h 3
http://www.d3lexicon.com/affix/of-stagnation-8 WeaponHitImmobilize1h 4
http://www.d3lexicon.com/affix/of-impairment-5 WeaponHitImmobilize1h 5
http://www.d3lexicon.com/affix/of-impairment-6 WeaponHitImmobilize1h 6
http://www.d3lexicon.com/affix/of-impairment-7 WeaponHitImmobilize1h 7
http://www.d3lexicon.com/affix/of-impairment-8 WeaponHitImmobilize1h 8
http://www.d3lexicon.com/affix/of-sabotage-4 WeaponHitImmobilize1h 9
http://www.d3lexicon.com/affix/of-sabotage-5 WeaponHitImmobilize1h 10
http://www.d3lexicon.com/affix/of-sabotage-6 WeaponHitImmobilize1h 11
http://www.d3lexicon.com/affix/of-paralysis-2 WeaponHitImmobilize1h 12
http://www.d3lexicon.com/affix/of-stagnation-9 WeaponHitImmobilize2h 1
http://www.d3lexicon.com/affix/of-stagnation-10 WeaponHitImmobilize2h 2
http://www.d3lexicon.com/affix/of-stagnation-11 WeaponHitImmobilize2h 3
http://www.d3lexicon.com/affix/of-stagnation-12 WeaponHitImmobilize2h 4
http://www.d3lexicon.com/affix/of-impairment-9 WeaponHitImmobilize2h 5
http://www.d3lexicon.com/affix/of-impairment-10 WeaponHitImmobilize2h 6
http://www.d3lexicon.com/affix/of-impairment-11 WeaponHitImmobilize2h 7
http://www.d3lexicon.com/affix/of-impairment-12 WeaponHitImmobilize2h 8
http://www.d3lexicon.com/affix/of-sabotage-7 WeaponHitImmobilize2h 9
http://www.d3lexicon.com/affix/of-sabotage-8 WeaponHitImmobilize2h 10
http://www.d3lexicon.com/affix/of-sabotage-9 WeaponHitImmobilize2h 11
http://www.d3lexicon.com/affix/of-paralysis-3 WeaponHitImmobilize2h 12
http://www.d3lexicon.com/affix/battering-5 WeaponHitKnockback1h 1
http://www.d3lexicon.com/affix/battering-6 WeaponHitKnockback1h 2
http://www.d3lexicon.com/affix/battering-7 WeaponHitKnockback1h 3
http://www.d3lexicon.com/affix/battering-8 WeaponHitKnockback1h 4
http://www.d3lexicon.com/affix/pummeling-5 WeaponHitKnockback1h 5
http://www.d3lexicon.com/affix/pummeling-6 WeaponHitKnockback1h 6
http://www.d3lexicon.com/affix/pummeling-7 WeaponHitKnockback1h 7
http://www.d3lexicon.com/affix/pummeling-8 WeaponHitKnockback1h 8
http://www.d3lexicon.com/affix/smashing-4 WeaponHitKnockback1h 9
http://www.d3lexicon.com/affix/smashing-5 WeaponHitKnockback1h 10
http://www.d3lexicon.com/affix/smashing-6 WeaponHitKnockback1h 11
http://www.d3lexicon.com/affix/pulverizing-2 WeaponHitKnockback1h 12
http://www.d3lexicon.com/affix/battering-9 WeaponHitKnockback2h 1
http://www.d3lexicon.com/affix/battering-10 WeaponHitKnockback2h 2
http://www.d3lexicon.com/affix/battering-11 WeaponHitKnockback2h 3
http://www.d3lexicon.com/affix/battering-12 WeaponHitKnockback2h 4
http://www.d3lexicon.com/affix/pummeling-9 WeaponHitKnockback2h 5
http://www.d3lexicon.com/affix/pummeling-10 WeaponHitKnockback2h 6
http://www.d3lexicon.com/affix/pummeling-11 WeaponHitKnockback2h 7
http://www.d3lexicon.com/affix/pummeling-12 WeaponHitKnockback2h 8
http://www.d3lexicon.com/affix/smashing-7 WeaponHitKnockback2h 9
http://www.d3lexicon.com/affix/smashing-8 WeaponHitKnockback2h 10
http://www.d3lexicon.com/affix/smashing-9 WeaponHitKnockback2h 11
http://www.d3lexicon.com/affix/pulverizing-3 WeaponHitKnockback2h 12
http://www.d3lexicon.com/affix/crippling-5 WeaponHitSlow1h 1
http://www.d3lexicon.com/affix/crippling-6 WeaponHitSlow1h 2
http://www.d3lexicon.com/affix/crippling-7 WeaponHitSlow1h 3
http://www.d3lexicon.com/affix/crippling-8 WeaponHitSlow1h 4
http://www.d3lexicon.com/affix/punishing-5 WeaponHitSlow1h 5
http://www.d3lexicon.com/affix/punishing-6 WeaponHitSlow1h 6
http://www.d3lexicon.com/affix/punishing-7 WeaponHitSlow1h 7
http://www.d3lexicon.com/affix/punishing-8 WeaponHitSlow1h 8
http://www.d3lexicon.com/affix/persecuting-4 WeaponHitSlow1h 9
http://www.d3lexicon.com/affix/persecuting-5 WeaponHitSlow1h 10
http://www.d3lexicon.com/affix/persecuting-6 WeaponHitSlow1h 11
http://www.d3lexicon.com/affix/dominating-2 WeaponHitSlow1h 12
http://www.d3lexicon.com/affix/crippling-9 WeaponHitSlow2h 1
http://www.d3lexicon.com/affix/crippling-10 WeaponHitSlow2h 2
http://www.d3lexicon.com/affix/crippling-11 WeaponHitSlow2h 3
http://www.d3lexicon.com/affix/crippling-12 WeaponHitSlow2h 4
http://www.d3lexicon.com/affix/punishing-9 WeaponHitSlow2h 5
http://www.d3lexicon.com/affix/punishing-10 WeaponHitSlow2h 6
http://www.d3lexicon.com/affix/punishing-11 WeaponHitSlow2h 7
http://www.d3lexicon.com/affix/punishing-12 WeaponHitSlow2h 8
http://www.d3lexicon.com/affix/persecuting-7 WeaponHitSlow2h 9
http://www.d3lexicon.com/affix/persecuting-8 WeaponHitSlow2h 10
http://www.d3lexicon.com/affix/persecuting-9 WeaponHitSlow2h 11
http://www.d3lexicon.com/affix/dominating-3 WeaponHitSlow2h 12
http://www.d3lexicon.com/affix/of-striking-5 WeaponHitStun1h 1
http://www.d3lexicon.com/affix/of-striking-6 WeaponHitStun1h 2
http://www.d3lexicon.com/affix/of-striking-7 WeaponHitStun1h 3
http://www.d3lexicon.com/affix/of-striking-8 WeaponHitStun1h 4
http://www.d3lexicon.com/affix/of-bane-5 WeaponHitStun1h 5
http://www.d3lexicon.com/affix/of-bane-6 WeaponHitStun1h 6
http://www.d3lexicon.com/affix/of-bane-7 WeaponHitStun1h 7
http://www.d3lexicon.com/affix/of-bane-8 WeaponHitStun1h 8
http://www.d3lexicon.com/affix/of-ruin-4 WeaponHitStun1h 9
http://www.d3lexicon.com/affix/of-ruin-5 WeaponHitStun1h 10
http://www.d3lexicon.com/affix/of-ruin-6 WeaponHitStun1h 11
http://www.d3lexicon.com/affix/of-devastation-3 WeaponHitStun1h 12
http://www.d3lexicon.com/affix/of-striking-9 WeaponHitStun2h 1
http://www.d3lexicon.com/affix/of-striking-10 WeaponHitStun2h 2
http://www.d3lexicon.com/affix/of-striking-11 WeaponHitStun2h 3
http://www.d3lexicon.com/affix/of-striking-12 WeaponHitStun2h 4
http://www.d3lexicon.com/affix/of-bane-9 WeaponHitStun2h 5
http://www.d3lexicon.com/affix/of-bane-10 WeaponHitStun2h 6
http://www.d3lexicon.com/affix/of-bane-11 WeaponHitStun2h 7
http://www.d3lexicon.com/affix/of-bane-12 WeaponHitStun2h 8
http://www.d3lexicon.com/affix/of-ruin-7 WeaponHitStun2h 9
http://www.d3lexicon.com/affix/of-ruin-8 WeaponHitStun2h 10
http://www.d3lexicon.com/affix/of-ruin-9 WeaponHitStun2h 11
http://www.d3lexicon.com/affix/of-devastation-4 WeaponHitStun2h 12";
        private const string Affix = @"-2145995947 MinMaxDam 1 Secondary
-2144486452 Thorns 15 Secondary
-2138793846 DexInt V Secondary
-2138183307 MinDam 7 Secondary
-2135462520 LightningResist 0.1 Legendary
-2131762116 PoisonD 2 Fast
-2124005782 DamageBonusPoison 1 Legendary
-2121970945 Regen 15 Secondary
-2114783997 Skill_Monk_Wayof100Fists 1
-2114783996 Skill_Monk_Wayof100Fists 2
-2114783995 Skill_Monk_Wayof100Fists 3
-2114783994 Skill_Monk_Wayof100Fists 4
-2114783993 Skill_Monk_Wayof100Fists 5
-2114783992 Skill_Monk_Wayof100Fists 6
-2114783991 Skill_Monk_Wayof100Fists 7
-2114783990 Skill_Monk_Wayof100Fists 8
-2107609951 Dex 8 Secondary
-2106694432 Skill_Wizard_ShockPulse 1
-2106694431 Skill_Wizard_ShockPulse 2
-2106694430 Skill_Wizard_ShockPulse 3
-2106694429 Skill_Wizard_ShockPulse 4
-2106694428 Skill_Wizard_ShockPulse 5
-2106694427 Skill_Wizard_ShockPulse 6
-2106694426 Skill_Wizard_ShockPulse 7
-2106694425 Skill_Wizard_ShockPulse 8
-2100110576 DR 2 Secondary
-2099275863 SpiritHeals 10
-2092626723 PoisonD 3 Fast
-2090456320 PrimaryAttribute_Str 5 Legendary
-2089077377 ArcaneResist III
-2089063220 ArcaneResist VII
-2089061042 ArcaneResist XII
-2088677743 DamageBonusHoly 4 Legendary
-2082601897 MinDam 10
-2082601896 MinDam 11
-2082601895 MinDam 12
-2082601894 MinDam 13
-2082601893 MinDam 14
-2080147913 IntVit VIII Secondary
-2067035827 DexVit VIII Secondary
-2064957999 DefenseMissile 10
-2064957998 DefenseMissile 11
-2064957997 DefenseMissile 12
-2060064773 DamageBonusLightning 6 Legendary
-2059320357 Skill_WitchDoctor_PoisonDart 1
-2059320356 Skill_WitchDoctor_PoisonDart 2
-2059320355 Skill_WitchDoctor_PoisonDart 3
-2059320354 Skill_WitchDoctor_PoisonDart 4
-2059320353 Skill_WitchDoctor_PoisonDart 5
-2059320352 Skill_WitchDoctor_PoisonDart 6
-2059320351 Skill_WitchDoctor_PoisonDart 7
-2059320350 Skill_WitchDoctor_PoisonDart 8
-2058758229 Skill_WitchDoctor_ZombieDogs 1
-2058758228 Skill_WitchDoctor_ZombieDogs 2
-2058758227 Skill_WitchDoctor_ZombieDogs 3
-2058758226 Skill_WitchDoctor_ZombieDogs 4
-2058758225 Skill_WitchDoctor_ZombieDogs 5
-2058758224 Skill_WitchDoctor_ZombieDogs 6
-2058758223 Skill_WitchDoctor_ZombieDogs 7
-2058758222 Skill_WitchDoctor_ZombieDogs 8
-2054936414 AllStats1H 15 Legendary
-2053491330 PoisonD 4 Fast
-2045570321 HitBlind 10
-2045570320 HitBlind 11
-2045570319 HitBlind 12
-2043699329 DamageReductionCold 1
-2043699328 DamageReductionCold 2
-2043699327 DamageReductionCold 3
-2043699326 DamageReductionCold 4
-2043699325 DamageReductionCold 5
-2043699324 DamageReductionCold 6
-2043699323 DamageReductionCold 7
-2043699322 DamageReductionCold 8
-2043699321 DamageReductionCold 9
-2043597633 Kings III Secondary
-2037686108 MF I Secondary
-2031143869 Str 11 Secondary
-2021317378 DamageBonusArcane 3 Legendary
-2020875089 MaxArcanePower 7 Legendary
-2019682371 MaxDiscipline 8 Legendary
-2014355937 PoisonD 5 Fast
-2012337776 LightningResist II
-2012337763 LightningResist IV
-2012337761 LightningResist IX
-2012337347 LightningResist VI
-2012337281 LightningResist XI
-2004947695 Regen 8 Secondary
-1999096624 IntVit XII Secondary
-1994776907 StrVit IX Secondary
-1984446229 Damage 0.3 Legendary
-1982878566 Superior Armor
-1982637063 LightningResist III
-1982622906 LightningResist VII
-1982620728 LightningResist XII
-1976254587 Sockets I
-1976254574 Sockets V
-1976254572 Sockets X
-1975220544 PoisonD 6 Fast
-1970572789 Int 8 Secondary
-1966072361 MinMaxDam 3 Secondary
-1958870260 DexInt X Secondary
-1958259721 MinDam 9 Secondary
-1955538934 LightningResist 0.3 Legendary
-1951487918 Regen 10
-1951487917 Regen 11
-1951487916 Regen 12
-1951487915 Regen 13
-1951487914 Regen 14
-1951487913 Regen 15
-1951487912 Regen 16
-1951487911 Regen 17
-1951487910 Regen 18
-1944082196 DamageBonusPoison 3 Legendary
-1942047359 Regen 17 Secondary
-1936085151 PoisonD 7 Fast
-1933662931 Vit 2 Secondary
-1933191965 DamageReductionFire 1
-1933191964 DamageReductionFire 2
-1933191963 DamageReductionFire 3
-1933191962 DamageReductionFire 4
-1933191961 DamageReductionFire 5
-1933191960 DamageReductionFire 6
-1933191959 DamageReductionFire 7
-1933191958 DamageReductionFire 8
-1933191957 DamageReductionFire 9
-1932769917 Life III Secondary
-1931540356 MF XI Secondary
-1920186990 DR 4 Secondary
-1918141165 Charge I
-1912297396 Kings VII Secondary
-1910532734 PrimaryAttribute_Str 7 Legendary
-1908754157 DamageBonusHoly 6 Legendary
-1908410994 Sockets Chest III
-1896949758 PoisonD 8 Fast
-1887777376 Skill_DemonHunter_Grenades 1
-1887777375 Skill_DemonHunter_Grenades 2
-1887777374 Skill_DemonHunter_Grenades 3
-1887777373 Skill_DemonHunter_Grenades 4
-1887777372 Skill_DemonHunter_Grenades 5
-1887777371 Skill_DemonHunter_Grenades 6
-1887777370 Skill_DemonHunter_Grenades 7
-1887777369 Skill_DemonHunter_Grenades 8
-1880309037 Str 2 Secondary
-1880141187 DamageBonusLightning 8 Legendary
-1870763435 MinDam 1 Fast
-1857814365 PoisonD 9 Fast
-1856705494 Inferior Weapon Dam 0
-1856705493 Inferior Weapon Dam 1
-1856705492 Inferior Weapon Dam 2
-1856705491 Inferior Weapon Dam 3
-1851220283 Str 13 Secondary
-1847999495 DamageReductionHoly 1
-1847999494 DamageReductionHoly 2
-1847999493 DamageReductionHoly 3
-1847999492 DamageReductionHoly 4
-1847999491 DamageReductionHoly 5
-1847999490 DamageReductionHoly 6
-1847999489 DamageReductionHoly 7
-1847999488 DamageReductionHoly 8
-1847999487 DamageReductionHoly 9
-1841393792 DamageBonusArcane 5 Legendary
-1840951503 MaxArcanePower 9 Legendary
-1831628042 MinDam 2 Fast
-1823774410 StrInt XII Secondary
-1823379498 CriticalChance I
-1823379485 CriticalChance V
-1820663116 FuryHeals 10
-1816578285 Life 0.2 Secondary Legendary
-1805263058 Rain of Gold I
-1802869037 DefenseMelee 1
-1802869036 DefenseMelee 2
-1802869035 DefenseMelee 3
-1802869034 DefenseMelee 4
-1802869033 DefenseMelee 5
-1802869032 DefenseMelee 6
-1802869031 DefenseMelee 7
-1802869030 DefenseMelee 8
-1802869029 DefenseMelee 9
-1801469680 Life VII Secondary
-1792492649 MinDam 3 Fast
-1788670210 HitLife 1 Secondary
-1786148775 MinMaxDam 5 Secondary
-1775613346 WeaponHitSlow1h 1
-1775613345 WeaponHitSlow1h 2
-1775613344 WeaponHitSlow1h 3
-1775613343 WeaponHitSlow1h 4
-1775613342 WeaponHitSlow1h 5
-1775613341 WeaponHitSlow1h 6
-1775613340 WeaponHitSlow1h 7
-1775613339 WeaponHitSlow1h 8
-1775613338 WeaponHitSlow1h 9
-1775577409 WeaponHitSlow2h 1
-1775577408 WeaponHitSlow2h 2
-1775577407 WeaponHitSlow2h 3
-1775577406 WeaponHitSlow2h 4
-1775577405 WeaponHitSlow2h 5
-1775577404 WeaponHitSlow2h 6
-1775577403 WeaponHitSlow2h 7
-1775577402 WeaponHitSlow2h 8
-1775577401 WeaponHitSlow2h 9
-1773842368 Powered Armor I
-1764158610 DamageBonusPoison 5 Legendary
-1762789227 StrVit XI Secondary
-1762370496 MinDam 11 Secondary
-1756042066 Skill_DemonHunter_Chakram 1
-1756042065 Skill_DemonHunter_Chakram 2
-1756042064 Skill_DemonHunter_Chakram 3
-1756042063 Skill_DemonHunter_Chakram 4
-1756042062 Skill_DemonHunter_Chakram 5
-1756042061 Skill_DemonHunter_Chakram 6
-1756042060 Skill_DemonHunter_Chakram 7
-1756042059 Skill_DemonHunter_Chakram 8
-1753739345 Vit 4 Secondary
-1753357256 MinDam 4 Fast
-1740263404 DR 6 Secondary
-1734300516 Vit 10 Secondary
-1730695322 ColdResist 0.1 Legendary
-1730609148 PrimaryAttribute_Str 9 Legendary
-1728830571 DamageBonusHoly 8 Legendary
-1714221863 MinDam 5 Fast
-1714146132 StrDex II
-1714146119 StrDex IV
-1714146117 StrDex IX
-1714145703 StrDex VI
-1714145637 StrDex XI
-1710668760 Skill_Barbarian_Whirlwind 1
-1710668759 Skill_Barbarian_Whirlwind 2
-1710668758 Skill_Barbarian_Whirlwind 3
-1710668757 Skill_Barbarian_Whirlwind 4
-1710668756 Skill_Barbarian_Whirlwind 5
-1710668755 Skill_Barbarian_Whirlwind 6
-1710668754 Skill_Barbarian_Whirlwind 7
-1710668753 Skill_Barbarian_Whirlwind 8
-1706427473 Crippling Shot I
-1704479244 Guardian I
-1702151079 Skill_Monk_DeadlyReach 1
-1702151078 Skill_Monk_DeadlyReach 2
-1702151077 Skill_Monk_DeadlyReach 3
-1702151076 Skill_Monk_DeadlyReach 4
-1702151075 Skill_Monk_DeadlyReach 5
-1702151074 Skill_Monk_DeadlyReach 6
-1702151073 Skill_Monk_DeadlyReach 7
-1702151072 Skill_Monk_DeadlyReach 8
-1700385451 Str 4 Secondary
-1697134579 DamageBonusArcane 11 Legendary
-1685987251 ArcaneResist I
-1685987238 ArcaneResist V
-1685987236 ArcaneResist X
-1685752077 DamConversionHeal 10
-1685752076 DamConversionHeal 11
-1685752075 DamConversionHeal 12
-1680663363 ArcaneD 10 Fast
-1677006694 Focused Mind I
-1675086470 MinDam 6 Fast
-1671296697 Str 15 Secondary
-1661470206 DamageBonusArcane 7 Legendary
-1653075881 ColdResist III
-1653061724 ColdResist VII
-1653059546 ColdResist XII
-1648110199 FireResist I
-1648110186 FireResist V
-1648110184 FireResist X
-1641527970 ArcaneD 11 Fast
-1638259419 ColdResist I
-1638259406 ColdResist V
-1638259404 ColdResist X
-1635951077 MinDam 7 Fast
-1625420711 SpiritHeals 1
-1625420710 SpiritHeals 2
-1625420709 SpiritHeals 3
-1625420708 SpiritHeals 4
-1625420707 SpiritHeals 5
-1625420706 SpiritHeals 6
-1625420705 SpiritHeals 7
-1625420704 SpiritHeals 8
-1625420703 SpiritHeals 9
-1620835717 DexVit IV Secondary
-1608746624 HitLife 3 Secondary
-1606225189 MinMaxDam 7 Secondary
-1604566875 Bleed 10 Secondary
-1604559965 Kings IV Secondary
-1604369411 KillLife 1
-1604369410 KillLife 2
-1604369409 KillLife 3
-1604369408 KillLife 4
-1604369407 KillLife 5
-1604369406 KillLife 6
-1604369405 KillLife 7
-1604369404 KillLife 8
-1604369403 KillLife 9
-1602392577 ArcaneD 12 Fast
-1596815684 MinDam 8 Fast
-1588784387 SpiritRegen 1
-1588784386 SpiritRegen 2
-1588784385 SpiritRegen 3
-1588784384 SpiritRegen 4
-1588784383 SpiritRegen 5
-1588784382 SpiritRegen 6
-1588784381 SpiritRegen 7
-1588784380 SpiritRegen 8
-1588784379 SpiritRegen 9
-1584235024 DamageBonusPoison 7 Legendary
-1582446910 MinDam 13 Secondary
-1574705269 Dex 11 Secondary
-1574438246 KillMana 1
-1574438245 KillMana 2
-1574438244 KillMana 3
-1574438243 KillMana 4
-1574438242 KillMana 5
-1574438241 KillMana 6
-1574438240 KillMana 7
-1574438239 KillMana 8
-1574438238 KillMana 9
-1573815759 Vit 6 Secondary
-1572235283 AllStats1H 1 Legendary
-1565068127 DamageReductionLightning 1
-1565068126 DamageReductionLightning 2
-1565068125 DamageReductionLightning 3
-1565068124 DamageReductionLightning 4
-1565068123 DamageReductionLightning 5
-1565068122 DamageReductionLightning 6
-1565068121 DamageReductionLightning 7
-1565068120 DamageReductionLightning 8
-1565068119 DamageReductionLightning 9
-1565011074 Skill_Monk_CripplingWave 1
-1565011073 Skill_Monk_CripplingWave 2
-1565011072 Skill_Monk_CripplingWave 3
-1565011071 Skill_Monk_CripplingWave 4
-1565011070 Skill_Monk_CripplingWave 5
-1565011069 Skill_Monk_CripplingWave 6
-1565011068 Skill_Monk_CripplingWave 7
-1565011067 Skill_Monk_CripplingWave 8
-1563257184 ArcaneD 13 Fast
-1562113230 DexVit V Secondary
-1560339818 DR 8 Secondary
-1560192489 Kings III
-1560178332 Kings VII
-1557680291 MinDam 9 Fast
-1554376930 Vit 12 Secondary
-1550771736 ColdResist 0.3 Legendary
-1537699442 Skill_Wizard_RayofFrost 1
-1537699441 Skill_Wizard_RayofFrost 2
-1537699440 Skill_Wizard_RayofFrost 3
-1537699439 Skill_Wizard_RayofFrost 4
-1537699438 Skill_Wizard_RayofFrost 5
-1537699437 Skill_Wizard_RayofFrost 6
-1537699436 Skill_Wizard_RayofFrost 7
-1537699435 Skill_Wizard_RayofFrost 8
-1524121791 ArcaneD 14 Fast
-1521300847 Life VIII
-1520461865 Str 6 Secondary
-1518146268 DamageBonusCold 10 Legendary
-1510128828 DamageVsElite 10 Secondary
-1507939626 StrInt II
-1507939613 StrInt IV
-1507939611 StrInt IX
-1507939197 StrInt VI
-1507939131 StrInt XI
-1481546620 DamageBonusArcane 9 Legendary
-1468274891 StrInt VIII
-1461069733 FireD 1
-1461069732 FireD 2
-1461069731 FireD 3
-1461069730 FireD 4
-1461069729 FireD 5
-1461069728 FireD 6
-1461069727 FireD 7
-1461069726 FireD 8
-1461069725 FireD 9
-1457835703 DamageBonusFire 11 Legendary
-1440912131 DexVit IX Secondary
-1434016043 Bleed 1 Secondary
-1431154284 DamageVsElite 1 Secondary
-1428823038 HitLife 5 Secondary
-1426301603 MinMaxDam 9 Secondary
-1424643289 Bleed 12 Secondary
-1419261702 WeaponHitImmobilize1h 10
-1419261701 WeaponHitImmobilize1h 11
-1419261700 WeaponHitImmobilize1h 12
-1418075781 WeaponHitImmobilize2h 10
-1418075780 WeaponHitImmobilize2h 11
-1418075779 WeaponHitImmobilize2h 12
-1415593161 HitImmobilize 10
-1415593160 HitImmobilize 11
-1415593159 HitImmobilize 12
-1409407349 GoldPickUpRadius 1
-1409407348 GoldPickUpRadius 2
-1409407347 GoldPickUpRadius 3
-1409407346 GoldPickUpRadius 4
-1409407345 GoldPickUpRadius 5
-1409407344 GoldPickUpRadius 6
-1404582963 KillLife 10
-1404582962 KillLife 11
-1404582961 KillLife 12
-1404582960 KillLife 13
-1404582959 KillLife 14
-1404311438 DamageBonusPoison 9 Legendary
-1394781683 Dex 13 Secondary
-1393892173 Vit 8 Secondary
-1392311697 AllStats1H 3 Legendary
-1387621786 MinMaxDam 11 Secondary
-1385819014 DamageBonusPoison 10 Legendary
-1385379000 CriticalChance III
-1385364843 CriticalChance VII
-1382189644 DexVit X Secondary
-1374453344 Vit 14 Secondary
-1374046024 Thorns 2 Secondary
-1365471283 MF II Secondary
-1362485177 LightningResist I
-1362485164 LightningResist V
-1362485162 LightningResist X
-1355456724 Skill_Wizard_ArcaneOrb 1
-1355456723 Skill_Wizard_ArcaneOrb 2
-1355456722 Skill_Wizard_ArcaneOrb 3
-1355456721 Skill_Wizard_ArcaneOrb 4
-1355456720 Skill_Wizard_ArcaneOrb 5
-1355456719 Skill_Wizard_ArcaneOrb 6
-1355456718 Skill_Wizard_ArcaneOrb 7
-1355456717 Skill_Wizard_ArcaneOrb 8
-1351470183 MaxFury 2 Legendary
-1349848392 RecognizedPrefix
-1347446219 Int 11 Secondary
-1340538279 Str 8 Secondary
-1338222682 DamageBonusCold 12 Legendary
-1332991111 Skill_DemonHunter_ElementalArrow 1
-1332991110 Skill_DemonHunter_ElementalArrow 2
-1332991109 Skill_DemonHunter_ElementalArrow 3
-1332991108 Skill_DemonHunter_ElementalArrow 4
-1332991107 Skill_DemonHunter_ElementalArrow 5
-1332991106 Skill_DemonHunter_ElementalArrow 6
-1332991105 Skill_DemonHunter_ElementalArrow 7
-1332991104 Skill_DemonHunter_ElementalArrow 8
-1330205242 DamageVsElite 12 Secondary
-1326263411 PrimaryAttribute_Str 11 Legendary
-1299215999 CriticalD 0.1 Secondary Legendary
-1292069147 Dirty Fighting I
-1275603273 Gold VIII
-1268813388 AllStats 1 Legendary
-1256761000 CriticalD I
-1256760987 CriticalD V
-1256760985 CriticalD X
-1254092457 Bleed 3 Secondary
-1251230698 DamageVsElite 3 Secondary
-1248899452 HitLife 7 Secondary
-1243749103 Damage II
-1243749090 Damage IV
-1243748674 Damage VI
-1234392307 Kings I Secondary
-1228848513 RecognizedSuffix
-1226015910 Amplify Damage I
-1224761404 MF VIII
-1222458671 Life I Secondary
-1217125170 Skill_Barbarian_Bash 1
-1217125169 Skill_Barbarian_Bash 2
-1217125168 Skill_Barbarian_Bash 3
-1217125167 Skill_Barbarian_Bash 4
-1217125166 Skill_Barbarian_Bash 5
-1217125165 Skill_Barbarian_Bash 6
-1217125164 Skill_Barbarian_Bash 7
-1217125163 Skill_Barbarian_Bash 8
-1214858097 Dex 15 Secondary
-1214251481 HitImmobilize 1
-1214251480 HitImmobilize 2
-1214251479 HitImmobilize 3
-1214251478 HitImmobilize 4
-1214251477 HitImmobilize 5
-1214251476 HitImmobilize 6
-1214251475 HitImmobilize 7
-1214251474 HitImmobilize 8
-1214251473 HitImmobilize 9
-1212388111 AllStats1H 5 Legendary
-1210749977 Life IV Secondary
-1208924451 DexVit XI Secondary
-1207698200 MinMaxDam 13 Secondary
-1205895428 DamageBonusPoison 12 Legendary
-1196720154 StrVit II Secondary
-1194529758 Vit 16 Secondary
-1194122438 Thorns 4 Secondary
-1192075499 DamageBonusCold 2 Legendary
-1190720556 Sockets Helm II
-1190720543 Sockets Helm IV
-1188183167 StrDex VI Secondary
-1177564964 DamageVsMonsterTypeHuman 1
-1177564963 DamageVsMonsterTypeHuman 2
-1177564962 DamageVsMonsterTypeHuman 3
-1177564961 DamageVsMonsterTypeHuman 4
-1177564960 DamageVsMonsterTypeHuman 5
-1177564959 DamageVsMonsterTypeHuman 6
-1177564958 DamageVsMonsterTypeHuman 7
-1177564957 DamageVsMonsterTypeHuman 8
-1177564956 DamageVsMonsterTypeHuman 9
-1176289900 CriticalChance VI Secondary
-1174673049 WeaponHitFear1h 10
-1174673048 WeaponHitFear1h 11
-1174673047 WeaponHitFear1h 12
-1173487128 WeaponHitFear2h 10
-1173487127 WeaponHitFear2h 11
-1173487126 WeaponHitFear2h 12
-1172921230 WeaponHitBlind1h 10
-1172921229 WeaponHitBlind1h 11
-1172921228 WeaponHitBlind1h 12
-1171735309 WeaponHitBlind2h 10
-1171735308 WeaponHitBlind2h 11
-1171735307 WeaponHitBlind2h 12
-1171546597 MaxFury 4 Legendary
-1167522633 Int 13 Secondary
-1164679370 KillLife 11 Secondary
-1160813507 DexInt I Secondary
-1153483251 Gold IV Secondary
-1149999050 CriticalD IV Secondary
-1146339825 PrimaryAttribute_Str 13 Legendary
-1144597881 DamageBonusLightning 11 Legendary
-1127898759 DamageBonusFire 2 Legendary
-1121260072 StrDex V Secondary
-1106287064 Skill_WitchDoctor_Firebats 1
-1106287063 Skill_WitchDoctor_Firebats 2
-1106287062 Skill_WitchDoctor_Firebats 3
-1106287061 Skill_WitchDoctor_Firebats 4
-1106287060 Skill_WitchDoctor_Firebats 5
-1106287059 Skill_WitchDoctor_Firebats 6
-1106287058 Skill_WitchDoctor_Firebats 7
-1106287057 Skill_WitchDoctor_Firebats 8
-1099325356 Charm I
-1096375804 FuryHeals 1

-1096375803 FuryHeals 2
-1096375802 FuryHeals 3
-1096375801 FuryHeals 4
-1096375800 FuryHeals 5
-1096375799 FuryHeals 6
-1096375798 FuryHeals 7
-1096375797 FuryHeals 8
-1096375796 FuryHeals 9
-1094496993 Rapid Fire I
-1089954242 Skill_WitchDoctor_FireBomb 1
-1089954241 Skill_WitchDoctor_FireBomb 2
-1089954240 Skill_WitchDoctor_FireBomb 3
-1089954239 Skill_WitchDoctor_FireBomb 4
-1089954238 Skill_WitchDoctor_FireBomb 5
-1089954237 Skill_WitchDoctor_FireBomb 6
-1089954236 Skill_WitchDoctor_FireBomb 7
-1089954235 Skill_WitchDoctor_FireBomb 8
-1088889802 AllStats 3 Legendary
-1078956226 Intidimidate I
-1076747262 WeaponHitBlind1h 1
-1076747261 WeaponHitBlind1h 2
-1076747260 WeaponHitBlind1h 3
-1076747259 WeaponHitBlind1h 4
-1076747258 WeaponHitBlind1h 5
-1076747257 WeaponHitBlind1h 6
-1076747256 WeaponHitBlind1h 7
-1076747255 WeaponHitBlind1h 8
-1076747254 WeaponHitBlind1h 9
-1076711325 WeaponHitBlind2h 1
-1076711324 WeaponHitBlind2h 2
-1076711323 WeaponHitBlind2h 3
-1076711322 WeaponHitBlind2h 4
-1076711321 WeaponHitBlind2h 5
-1076711320 WeaponHitBlind2h 6
-1076711319 WeaponHitBlind2h 7
-1076711318 WeaponHitBlind2h 8
-1076711317 WeaponHitBlind2h 9
-1075172573 Skill_Monk_WaveofLight 1
-1075172572 Skill_Monk_WaveofLight 2
-1075172571 Skill_Monk_WaveofLight 3
-1075172570 Skill_Monk_WaveofLight 4
-1075172569 Skill_Monk_WaveofLight 5
-1075172568 Skill_Monk_WaveofLight 6
-1075172567 Skill_Monk_WaveofLight 7
-1075172566 Skill_Monk_WaveofLight 8
-1074168871 Bleed 5 Secondary
-1071448695 Guidance I
-1071307112 DamageVsElite 5 Secondary
-1068975866 HitLife 9 Secondary
-1066811484 Block 1 Secondary
-1063178769 DexVit III
-1063164612 DexVit VII
-1063162434 DexVit XII
-1062339227 MinDam 10 Fast
-1054095993 ColdD 10
-1054095992 ColdD 11
-1054095991 ColdD 12
-1054095990 ColdD 13
-1054095989 ColdD 14
-1051790324 Sockets Belt I
-1051790311 Sockets Belt V
-1039471217 IntVit VIII
-1032464525 AllStats1H 7 Legendary
-1030826391 Life IX Secondary
-1023203834 MinDam 11 Fast

-1014198852 Thorns 6 Secondary
-1014170316 DamageVsMonsterTypeUndead 1
-1014170315 DamageVsMonsterTypeUndead 2
-1014170314 DamageVsMonsterTypeUndead 3
-1014170313 DamageVsMonsterTypeUndead 4
-1014170312 DamageVsMonsterTypeUndead 5
-1014170311 DamageVsMonsterTypeUndead 6
-1014170310 DamageVsMonsterTypeUndead 7
-1014170309 DamageVsMonsterTypeUndead 8
-1014170308 DamageVsMonsterTypeUndead 9
-1012151913 DamageBonusCold 4 Legendary
-1008238679 LightningD 10
-1008238678 LightningD 11
-1008238677 LightningD 12
-1008238676 LightningD 13
-1008238675 LightningD 14
-1005109122 StrVit II
-1005109109 StrVit IV
-1005109107 StrVit IX
-1005108693 StrVit VI
-1005108627 StrVit XI
-1002046353 LightningResist VIII
-995219665 Skill_DemonHunter_Impale 1
-995219664 Skill_DemonHunter_Impale 2
-995219663 Skill_DemonHunter_Impale 3
-995219662 Skill_DemonHunter_Impale 4
-995219661 Skill_DemonHunter_Impale 5
-995219660 Skill_DemonHunter_Impale 6
-995219659 Skill_DemonHunter_Impale 7
-995219658 Skill_DemonHunter_Impale 8
-991795643 AllStats 11 Legendary
-991623011 MaxFury 6 Legendary
-987599047 Int 15 Secondary
-984755784 KillLife 13 Secondary
-984222910 StrInt V Secondary
-984068441 MinDam 12 Fast
-979929723 PrimaryAttribute_Dex 2 Legendary
-976182126 DamageVsMonsterTypeBeast 1
-976182125 DamageVsMonsterTypeBeast 2
-976182124 DamageVsMonsterTypeBeast 3
-976182123 DamageVsMonsterTypeBeast 4
-976182122 DamageVsMonsterTypeBeast 5
-976182121 DamageVsMonsterTypeBeast 6
-976182120 DamageVsMonsterTypeBeast 7
-976182119 DamageVsMonsterTypeBeast 8
-976182118 DamageVsMonsterTypeBeast 9
-973559665 Gold IX Secondary
-970660885 FireD 10
-970660884 FireD 11
-970660883 FireD 12
-970660882 FireD 13
-970660881 FireD 14
-970075464 CriticalD IX Secondary
-966416239 PrimaryAttribute_Str 15 Legendary
-965681604 Skill_Barbarian_HotA 1
-965681603 Skill_Barbarian_HotA 2
-965681602 Skill_Barbarian_HotA 3
-965681601 Skill_Barbarian_HotA 4
-965681600 Skill_Barbarian_HotA 5
-965681599 Skill_Barbarian_HotA 6
-965681598 Skill_Barbarian_HotA 7
-965681597 Skill_Barbarian_HotA 8
-960924117 StrInt VI Secondary
-947975173 DamageBonusFire 4 Legendary
-944933048 MinDam 13 Fast
-941336486 StrDex X Secondary
-939099115 DexInt I
-939099102 DexInt V
-939099100 DexInt X
-927134854 Disorient I
-926180037 PoisonResist I
-926180024 PoisonResist V
-926180022 PoisonResist X
-925499618 DexInt II
-925499605 DexInt IV
-925499603 DexInt IX
-925499189 DexInt VI
-925499123 DexInt XI
-923861827 DexVit I
-923861814 DexVit V
-923861812 DexVit X
-922564110 MaxDam 2 Secondary
-914352370 ResistAll III
-914338213 ResistAll VII
-914336035 ResistAll XII
-908966216 AllStats 5 Legendary
-906528857 DamageReductionArcane 1
-906528856 DamageReductionArcane 2
-906528855 DamageReductionArcane 3
-906528854 DamageReductionArcane 4
-906528853 DamageReductionArcane 5
-906528852 DamageReductionArcane 6
-906528851 DamageReductionArcane 7
-906528850 DamageReductionArcane 8
-906528849 DamageReductionArcane 9
-905797655 MinDam 14 Fast
-903243243 DamageReductionPoison 1
-903243242 DamageReductionPoison 2
-903243241 DamageReductionPoison 3
-903243240 DamageReductionPoison 4
-903243239 DamageReductionPoison 5
-903243238 DamageReductionPoison 6
-903243237 DamageReductionPoison 7
-903243236 DamageReductionPoison 8
-903243235 DamageReductionPoison 9
-894245285 Bleed 7 Secondary
-891383526 DamageVsElite 7 Secondary
-890277171 SpiritRegen 10
-887142961 ManaRegen 10
-886887898 Block 3 Secondary
-883808802 StrVit XII Secondary
-869824811 PrimaryAttribute_Dex 11 Legendary
-868405876 Lower Resist I
-861511570 Skill_Barbarian_WeaponThrow 1
-861511569 Skill_Barbarian_WeaponThrow 2
-861511568 Skill_Barbarian_WeaponThrow 3
-861511567 Skill_Barbarian_WeaponThrow 4
-861511566 Skill_Barbarian_WeaponThrow 5
-861511565 Skill_Barbarian_WeaponThrow 6
-861511564 Skill_Barbarian_WeaponThrow 7
-861511563 Skill_Barbarian_WeaponThrow 8
-857169251 PoisonD 10
-857169250 PoisonD 11
-857169249 PoisonD 12
-857169248 PoisonD 13
-857169247 PoisonD 14
-854441143 DamageReductionHoly 10
-854441142 DamageReductionHoly 11
-854441141 DamageReductionHoly 12
-854093758 Skill_Monk_CycloneStrike 1
-854093757 Skill_Monk_CycloneStrike 2
-854093756 Skill_Monk_CycloneStrike 3
-854093755 Skill_Monk_CycloneStrike 4
-854093754 Skill_Monk_CycloneStrike 5
-854093753 Skill_Monk_CycloneStrike 6
-854093752 Skill_Monk_CycloneStrike 7
-854093751 Skill_Monk_CycloneStrike 8
-852540939 AllStats1H 9 Legendary
-846894066 MaxArcanePower 1
-846894065 MaxArcanePower 2
-846894064 MaxArcanePower 3
-846894063 MaxArcanePower 4
-846894062 MaxArcanePower 5
-846894061 MaxArcanePower 6
-846894060 MaxArcanePower 7
-846894059 MaxArcanePower 8
-846894058 MaxArcanePower 9
-843477631 DefenseMissile 1
-843477630 DefenseMissile 2
-843477629 DefenseMissile 3
-843477628 DefenseMissile 4
-843477627 DefenseMissile 5
-843477626 DefenseMissile 6
-843477625 DefenseMissile 7
-843477624 DefenseMissile 8
-843477623 DefenseMissile 9
-842892561 PrimaryAttribute_Int 2 Legendary
-841152866 CCReduction 0.2 Legendary
-837734875 KillLife 1 Secondary
-834275266 Thorns 8 Secondary
-832228327 DamageBonusCold 6 Legendary
-816985589 Sockets Helm I
-816985576 Sockets Helm V
-814050226 Knight I
-812845449 ColdD 1
-812845448 ColdD 2
-812845447 ColdD 3
-812845446 ColdD 4
-812845445 ColdD 5
-812845444 ColdD 6
-812845443 ColdD 7
-812845442 ColdD 8
-812845441 ColdD 9
-811872057 AllStats 13 Legendary
-811699425 MaxFury 8 Legendary
-805413895 Intervene I
-804299324 StrInt X Secondary
-800006137 PrimaryAttribute_Dex 4 Legendary
-792694289 Haste 2 Secondary
-792573035 Scavenge I
-791891826 Sockets II
-791891813 Sockets IV
-791891811 Sockets IX
-791891397 Sockets VI
-791891331 Sockets XI
-791891318 Sockets XV
-789460967 CriticalD 0.1 Legendary
-783511600 Skill_DemonHunter_EvasiveFire 1
-783511599 Skill_DemonHunter_EvasiveFire 2
-783511598 Skill_DemonHunter_EvasiveFire 3
-783511597 Skill_DemonHunter_EvasiveFire 4
-783511596 Skill_DemonHunter_EvasiveFire 5
-783511595 Skill_DemonHunter_EvasiveFire 6
-783511594 Skill_DemonHunter_EvasiveFire 7
-783511593 Skill_DemonHunter_EvasiveFire 8
-768051587 DamageBonusFire 6 Legendary
-760680002 Onslaught I
-748387241 Reflect Missiles I
-742640524 MaxDam 4 Secondary
-739279646 PhysicalResist 0.2 Legendary
-733388468 StrDex XII Secondary
-732247403 StrDex III
-732233246 StrDex VII
-732231068 StrDex XII
-729042630 AllStats 7 Legendary
-726105986 DexInt XII Secondary
-724693723 DexVit VIII
-718070093 Skill_DemonHunter_BolaShot 1
-718070092 Skill_DemonHunter_BolaShot 2
-718070091 Skill_DemonHunter_BolaShot 3
-718070090 Skill_DemonHunter_BolaShot 4
-718070089 Skill_DemonHunter_BolaShot 5
-718070088 Skill_DemonHunter_BolaShot 6
-718070087 Skill_DemonHunter_BolaShot 7
-718070086 Skill_DemonHunter_BolaShot 8
-717473313 Forceful Push I
-714321699 Bleed 9 Secondary
-711459940 DamageVsElite 9 Secondary
-706964312 Block 5 Secondary
-694660064 DR 11 Secondary
-689901225 PrimaryAttribute_Dex 13 Legendary
-685810817 HolyD 1 Fast
-669278121 ArcanePowerOnCrit 1
-669278120 ArcanePowerOnCrit 2
-669278119 ArcanePowerOnCrit 3
-669278118 ArcanePowerOnCrit 4
-669278117 ArcanePowerOnCrit 5
-669278116 ArcanePowerOnCrit 6
-669278115 ArcanePowerOnCrit 7
-669278114 ArcanePowerOnCrit 8
-669278113 ArcanePowerOnCrit 9
-662968975 PrimaryAttribute_Int 4 Legendary
-662746861 Energy Bomb I
-658199107 PoisonResist 0.2 Legendary
-657811289 KillLife 3 Secondary
-657218538 MF III Secondary
-652304741 DamageBonusCold 8 Legendary
-646675424 HolyD 2 Fast
-642855378 DexVit II Secondary
-642565761 PrimaryAttribute_Int 11 Legendary
-639072579 Sockets Helm III
-631948471 AllStats 15 Legendary
-626579626 Kings II Secondary
-624571637 FireResist 0.2 Legendary
-620082551 PrimaryAttribute_Dex 6 Legendary
-613608497 HolyD 10 Fast
-612770703 Haste 4 Secondary
-611341465 ArcanePowerOnCrit 10
-609537381 CriticalD 0.3 Legendary
-607540031 HolyD 3 Fast
-589858854 Dex 1 Secondary
-589482147 StrInt VIII Secondary
-588128001 DamageBonusFire 8 Legendary
-586399239 Skill_Barbarian_Rend 1
-586399238 Skill_Barbarian_Rend 2
-586399237 Skill_Barbarian_Rend 3
-586399236 Skill_Barbarian_Rend 4
-586399235 Skill_Barbarian_Rend 5
-586399234 Skill_Barbarian_Rend 6
-586399233 Skill_Barbarian_Rend 7
-586399232 Skill_Barbarian_Rend 8
-584132891 DexVit I Secondary
-575785339 IntVit VI Secondary
-575064451 Bleed 10
-575064450 Bleed 11
-575064449 Bleed 12
-574473104 HolyD 11 Fast
-568404638 HolyD 4 Fast
-562716938 MaxDam 6 Secondary
-556796117 Life 0.2 Legendary
-553092101 MinMaxDam 1 Fast
-549119044 AllStats 9 Legendary
-536624527 FireResist VIII
-535337711 HolyD 12 Fast
-532368674 Sockets Shield I
-532368661 Sockets Shield V
-529329636 ResistAll I
-529329623 ResistAll V
-529329621 ResistAll X
-529269245 HolyD 5 Fast
-528858165 MinMaxDam 10 Fast
-527040726 Block 7 Secondary
-525984817 ArcaneResist 0.2 Legendary
-525918301 MF VII Secondary
-520098995 Sockets Amulet I
-520098982 Sockets Amulet V
-514736478 DR 13 Secondary
-513956708 MinMaxDam 2 Fast
-512094249 Loyalty I
-509977639 PrimaryAttribute_Dex 15 Legendary
-502510711 MaxDam 1
-502510710 MaxDam 2
-502510709 MaxDam 3
-502510708 MaxDam 4
-502510707 MaxDam 5
-502510706 MaxDam 6
-502510705 MaxDam 7
-502510704 MaxDam 8
-502510703 MaxDam 9
-501931274 MaxDiscipline 1 Legendary
-499170044 PoisonResist II
-499170031 PoisonResist IV
-499170029 PoisonResist IX
-499169615 PoisonResist VI
-499169549 PoisonResist XI
-498686399 IntVit III Secondary
-496202318 HolyD 13 Fast
-490332350 MaxDam 11 Secondary
-490133852 HolyD 6 Fast
-489722772 MinMaxDam 11 Fast
-489392194 Skill_WitchDoctor_CorpseSpiders 1
-489392193 Skill_WitchDoctor_CorpseSpiders 2
-489392192 Skill_WitchDoctor_CorpseSpiders 3
-489392191 Skill_WitchDoctor_CorpseSpiders 4
-489392190 Skill_WitchDoctor_CorpseSpiders 5
-489392189 Skill_WitchDoctor_CorpseSpiders 6
-489392188 Skill_WitchDoctor_CorpseSpiders 7
-489392187 Skill_WitchDoctor_CorpseSpiders 8
-487196598 Regen 1 Secondary
-483045389 PrimaryAttribute_Int 6 Legendary
-477887703 KillLife 5 Secondary
-476716217 DexInt III
-476702060 DexInt VII
-476699882 DexInt XII
-474821315 MinMaxDam 3 Fast
-474368107 Skill_Monk_LashingTailKick 1
-474368106 Skill_Monk_LashingTailKick 2
-474368105 Skill_Monk_LashingTailKick 3
-474368104 Skill_Monk_LashingTailKick 4
-474368103 Skill_Monk_LashingTailKick 5
-474368102 Skill_Monk_LashingTailKick 6
-474368101 Skill_Monk_LashingTailKick 7
-474368100 Skill_Monk_LashingTailKick 8
-467331770 Skill_WitchDoctor_PlagueofToads 1
-467331769 Skill_WitchDoctor_PlagueofToads 2
-467331768 Skill_WitchDoctor_PlagueofToads 3
-467331767 Skill_WitchDoctor_PlagueofToads 4
-467331766 Skill_WitchDoctor_PlagueofToads 5
-467331765 Skill_WitchDoctor_PlagueofToads 6
-467331764 Skill_WitchDoctor_PlagueofToads 7
-467331763 Skill_WitchDoctor_PlagueofToads 8
-462642175 PrimaryAttribute_Int 13 Legendary
-457066925 HolyD 14 Fast
-456773228 Life 0.3 Secondary Legendary
-452821692 Int 1 Secondary
-450998459 HolyD 7 Fast
-450587379 MinMaxDam 12 Fast
-446811769 Thorns 10 Secondary
-446314849 DamageBonusHoly 11 Legendary
-444399684 Skill_Barbarian_Revenge 1
-444399683 Skill_Barbarian_Revenge 2
-444399682 Skill_Barbarian_Revenge 3
-444399681 Skill_Barbarian_Revenge 4
-444399680 Skill_Barbarian_Revenge 5
-444399679 Skill_Barbarian_Revenge 6
-444399678 Skill_Barbarian_Revenge 7
-444399677 Skill_Barbarian_Revenge 8
-440508624 MinDam 2 Secondary
-440158965 PrimaryAttribute_Dex 8 Legendary
-435685922 MinMaxDam 4 Fast
-434632372 Poison Arrow I
-432847117 Haste 6 Secondary
-430720647 FireD 10 Fast
-427013688 CriticalD VIII Secondary
-424296262 Regen 10 Secondary
-423252498 HitLife 10 Secondary
-422669114 DexVit II
-422669101 DexVit IV
-422669099 DexVit IX
-422668685 DexVit VI
-422668619 DexVit XI
-416854518 KillMana 10
-416854517 KillMana 11
-416854516 KillMana 12
-411863066 HolyD 8 Fast
-411451986 MinMaxDam 13 Fast
-409935268 Dex 3 Secondary
-407542294 StrVit V Secondary
-407059341 DexInt VI Secondary
-400894308 Skill_WitchDoctor_LocustSwarm 1
-400894307 Skill_WitchDoctor_LocustSwarm 2
-400894306 Skill_WitchDoctor_LocustSwarm 3
-400894305 Skill_WitchDoctor_LocustSwarm 4
-400894304 Skill_WitchDoctor_LocustSwarm 5
-400894303 Skill_WitchDoctor_LocustSwarm 6
-400894302 Skill_WitchDoctor_LocustSwarm 7
-400894301 Skill_WitchDoctor_LocustSwarm 8
-396550529 MinMaxDam 5 Fast
-391585254 FireD 11 Fast
-388296953 Sockets Shield II
-388296940 Sockets Shield IV
-387046238 Anatomy I
-382793352 MaxDam 8 Secondary
-372727673 HolyD 9 Fast
-372316593 MinMaxDam 14 Fast
-367386162 IntVit VII Secondary
-362626377 Sockets III
-362612220 Sockets VII
-362610042 Sockets XII
-362610029 Sockets XIV
-362609613 Sockets XVI
-362390090 DamageBonusLightning 1 Legendary
-357415136 MinMaxDam 6 Fast
-357261731 AllStats1H 10 Legendary
-352449861 FireD 12 Fast
-349342219 Sockets Belt II
-349342206 Sockets Belt IV
-347117140 Block 9 Secondary
-346524133 Skill_Wizard_EnergyTwister 1
-346524132 Skill_Wizard_EnergyTwister 2
-346524131 Skill_Wizard_EnergyTwister 3
-346524130 Skill_Wizard_EnergyTwister 4
-346524129 Skill_Wizard_EnergyTwister 5
-346524128 Skill_Wizard_EnergyTwister 6
-346524127 Skill_Wizard_EnergyTwister 7
-346524126 Skill_Wizard_EnergyTwister 8
-334812892 DR 15 Secondary
-324328061 Inspire I
-323364185 StrInt III Secondary
-323200406 MaxArcanePower 2 Legendary
-322007688 MaxDiscipline 3 Legendary
-318279743 MinMaxDam 7 Fast
-313314468 FireD 13 Fast
-310408764 MaxDam 13 Secondary
-307273012 Regen 3 Secondary
-303121803 PrimaryAttribute_Int 8 Legendary
-297964117 KillLife 7 Secondary
-288008699 ResistAll II
-288008686 ResistAll IV
-288008684 ResistAll IX
-288008270 ResistAll VI
-288008204 ResistAll XI
-283720570 HitLife 10
-283720569 HitLife 11
-283720568 HitLife 12
-283720567 HitLife 13
-283720566 HitLife 14
-283685984 Skill_DemonHunter_Multishot 1
-283685983 Skill_DemonHunter_Multishot 2
-283685982 Skill_DemonHunter_Multishot 3
-283685981 Skill_DemonHunter_Multishot 4
-283685980 Skill_DemonHunter_Multishot 5
-283685979 Skill_DemonHunter_Multishot 6
-283685978 Skill_DemonHunter_Multishot 7
-283685977 Skill_DemonHunter_Multishot 8
-282718589 PrimaryAttribute_Int 15 Legendary
-280637813 DamageVsMonsterTypeBeast 0.1 Legendary
-279144350 MinMaxDam 8 Fast
-274179075 FireD 14 Fast
-272898106 Int 3 Secondary
-266888183 Thorns 12 Secondary
-261830947 ResistAll 0.1 Legendary
-260585038 MinDam 4 Secondary
-257301022 Dex 10
-257301021 Dex 11
-257301020 Dex 12
-257301019 Dex 13
-257301018 Dex 14
-257301017 Dex 15
-257301016 Dex 16
-252923531 Haste 8 Secondary
-251315149 Charged Bolt Cast I
-250946460 CCReduction 1
-250946459 CCReduction 2
-250946458 CCReduction 3
-250946457 CCReduction 4
-250946456 CCReduction 5
-250946455 CCReduction 6
-246340211 CriticalD V Secondary
-244372676 Regen 12 Secondary
-243328912 HitLife 12 Secondary
-240008957 MinMaxDam 9 Fast
-234397216 WeaponHitKnockback1h 1
-234397215 WeaponHitKnockback1h 2
-234397214 WeaponHitKnockback1h 3
-234397213 WeaponHitKnockback1h 4
-234397212 WeaponHitKnockback1h 5
-234397211 WeaponHitKnockback1h 6
-234397210 WeaponHitKnockback1h 7
-234397209 WeaponHitKnockback1h 8
-234397208 WeaponHitKnockback1h 9
-234361279 WeaponHitKnockback2h 1
-234361278 WeaponHitKnockback2h 2
-234361277 WeaponHitKnockback2h 3
-234361276 WeaponHitKnockback2h 4
-234361275 WeaponHitKnockback2h 5
-234361274 WeaponHitKnockback2h 6
-234361273 WeaponHitKnockback2h 7
-234361272 WeaponHitKnockback2h 8
-234361271 WeaponHitKnockback2h 9
-232769638 Life II Secondary
-230011682 Dex 5 Secondary
-227618708 StrVit X Secondary
-219609419 ArcaneResist VIII
-212858051 PrimaryAttribute_Str 2 Legendary
-211079474 DamageBonusHoly 1 Legendary
-204938100 DamageVsMonsterTypeHuman 10
-204938099 DamageVsMonsterTypeHuman 11
-204938098 DamageVsMonsterTypeHuman 12
-192137505 HitBlind 1
-192137504 HitBlind 2
-192137503 HitBlind 3
-192137502 HitBlind 4
-192137501 HitBlind 5
-192137500 HitBlind 6
-192137499 HitBlind 7
-192137498 HitBlind 8
-192137497 HitBlind 9
-192063948 StrInt VII Secondary
-182466504 DamageBonusLightning 3 Legendary
-178964486 ResistStunRootFreeze 1
-177338145 AllStats1H 12 Legendary
-175502912 Gold II Secondary
-172018711 CriticalD II Secondary
-167803620 Skill_DemonHunter_EntanglingShot 1
-167803619 Skill_DemonHunter_EntanglingShot 2
-167803618 Skill_DemonHunter_EntanglingShot 3
-167803617 Skill_DemonHunter_EntanglingShot 4
-167803616 Skill_DemonHunter_EntanglingShot 5
-167803615 Skill_DemonHunter_EntanglingShot 6
-167803614 Skill_DemonHunter_EntanglingShot 7
-167803613 Skill_DemonHunter_EntanglingShot 8
-154889306 DR 17 Secondary
-143279733 StrDex I Secondary
-143276820 MaxArcanePower 4 Legendary
-142084102 MaxDiscipline 5 Legendary
-140235601 ArcaneD 10
-140235600 ArcaneD 11
-140235599 ArcaneD 12
-140235598 ArcaneD 13
-140235597 ArcaneD 14
-134342887 Skill_Barbarian_Overpower 1
-134342886 Skill_Barbarian_Overpower 2
-134342885 Skill_Barbarian_Overpower 3
-134342884 Skill_Barbarian_Overpower 4
-134342883 Skill_Barbarian_Overpower 5
-134342882 Skill_Barbarian_Overpower 6
-134342881 Skill_Barbarian_Overpower 7
-134342880 Skill_Barbarian_Overpower 8
-128393329 Gold I
-128393316 Gold V
-128393314 Gold X
-127349426 Regen 5 Secondary
-124762894 Superior Weapon MaxDmg 1
-124762893 Superior Weapon MaxDmg 2
-124762892 Superior Weapon MaxDmg 3
-124762891 Superior Weapon MaxDmg 4
-124762890 Superior Weapon MaxDmg 5
-124762889 Superior Weapon MaxDmg 6
-118040531 KillLife 9 Secondary
-108389852 ResistAll VIII
-107640591 DamageReductionLightning 10
-107640590 DamageReductionLightning 11
-107640589 DamageReductionLightning 12
-105644907 ColdD 10 Fast
-101503741 Heal I
-97081027 Sockets Bracer II
-97081014 Sockets Bracer IV
-92974520 Int 5 Secondary
-86964597 Thorns 14 Secondary
-82999401 HitFreeze 1
-82999400 HitFreeze 2
-82999399 HitFreeze 3
-82999398 HitFreeze 4
-82999397 HitFreeze 5
-82999396 HitFreeze 6
-82999395 HitFreeze 7
-82999394 HitFreeze 8
-82999393 HitFreeze 9
-81907361 ResistAll 0.3 Legendary
-80661452 MinDam 6 Secondary
-79695477 CriticalChance V Secondary
-66509514 ColdD 11 Fast
-66416625 CriticalD X Secondary
-65018252 Power Shot I
-64449090 Regen 14 Secondary
-63405326 HitLife 14 Secondary
-51094516 Int 10
-51094515 Int 11
-51094514 Int 12
-51094513 Int 13
-51094512 Int 14
-51094511 Int 15
-51094510 Int 16
-50088096 Dex 7 Secondary
-42967959 Gold III Secondary
-42588721 DR 1 Secondary
-41981185 CriticalChance II
-41981172 CriticalChance IV
-41981170 CriticalChance IX
-41980756 CriticalChance VI
-32934465 PrimaryAttribute_Str 4 Legendary
-31155888 DamageBonusHoly 3 Legendary
-27374121 ColdD 12 Fast
-24567465 Skill_Monk_ExplodingPalm 1
-24567464 Skill_Monk_ExplodingPalm 2
-24567463 Skill_Monk_ExplodingPalm 3
-24567462 Skill_Monk_ExplodingPalm 4
-24567461 Skill_Monk_ExplodingPalm 5
-24567460 Skill_Monk_ExplodingPalm 6
-24567459 Skill_Monk_ExplodingPalm 7
-24567458 Skill_Monk_ExplodingPalm 8
-20084219 Superior Weapon Speed 1
-20084218 Superior Weapon Speed 2
-20084217 Superior Weapon Speed 3
-20084216 Superior Weapon Speed 4
-20084215 Superior Weapon Speed 5
-20084214 Superior Weapon Speed 6
-20018901 MaxDiscipline 10
-6242571 StrInt I Secondary
-2542918 DamageBonusLightning 5 Legendary
211196 DamReductionVsElite 10
211197 DamReductionVsElite 11
211198 DamReductionVsElite 12
2585441 AllStats1H 14 Legendary
3718951 DR 1
3718952 DR 2
3718953 DR 3
3718954 DR 4
3718955 DR 5
3718956 DR 6
3718957 DR 7
3718958 DR 8
3718959 DR 9
4029372 MF I
4029385 MF V
4029387 MF X
11761272 ColdD 13 Fast
16602454 Sockets Amulet II
16602467 Sockets Amulet IV
25034280 DR 19 Secondary
26377986 Str 10 Secondary
29193161 Skill_DemonHunter_HungeringArrow 1
29193162 Skill_DemonHunter_HungeringArrow 2
29193163 Skill_DemonHunter_HungeringArrow 3
29193164 Skill_DemonHunter_HungeringArrow 4
29193165 Skill_DemonHunter_HungeringArrow 5
29193166 Skill_DemonHunter_HungeringArrow 6
29193167 Skill_DemonHunter_HungeringArrow 7
29193168 Skill_DemonHunter_HungeringArrow 8
35341959 Skill_Monk_TempestRush 1
35341960 Skill_Monk_TempestRush 2
35341961 Skill_Monk_TempestRush 3
35341962 Skill_Monk_TempestRush 4
35341963 Skill_Monk_TempestRush 5
35341964 Skill_Monk_TempestRush 6
35341965 Skill_Monk_TempestRush 7
35341966 Skill_Monk_TempestRush 8
36204477 DamageBonusArcane 2 Legendary
36646766 MaxArcanePower 6 Legendary
37839484 MaxDiscipline 7 Legendary
42416609 StrDex IV Secondary
50896665 ColdD 14 Fast
52574160 Regen 7 Secondary
54309876 CriticalChance IV Secondary
57987544 Gold II
57987557 Gold IV
57987559 Gold IX
57987973 Gold VI
59953577 Life I
59953590 Life V
60589058 CriticalD 0.2 Secondary Legendary
71102544 Sockets Shield III
72010674 CriticalD III Secondary
73075626 Damage 0.2 Legendary
73658719 Gold VIII Secondary
77013533 Decoy I
86116171 Skill_Wizard_Meteor 1
86116172 Skill_Wizard_Meteor 2
86116173 Skill_Wizard_Meteor 3
86116174 Skill_Wizard_Meteor 4
86116175 Skill_Wizard_Meteor 5
86116176 Skill_Wizard_Meteor 6
86116177 Skill_Wizard_Meteor 7
86116178 Skill_Wizard_Meteor 8
86949066 Int 7 Secondary
88332278 Gold VII Secondary
91449494 MinMaxDam 2 Secondary
93022382 MF III
93036539 MF VII
99262134 MinDam 8 Secondary
101982921 LightningResist 0.2 Legendary
113439659 DamageBonusPoison 2 Legendary
115474496 Regen 16 Secondary
122353522 Dex 1
122353523 Dex 2
122353524 Dex 3
122353525 Dex 4
122353526 Dex 5
122353527 Dex 6
122353528 Dex 7
122353529 Dex 8
122353530 Dex 9
122725431 DR 10
122725432 DR 11
122725433 DR 12
122725434 DR 13
122725435 DR 14
122725436 DR 15
122725437 DR 16
122725438 DR 17
122725439 DR 18
122725440 DR 19
123858924 Vit 1 Secondary
125900959 ArcaneD 1
125900960 ArcaneD 2
125900961 ArcaneD 3
125900962 ArcaneD 4
125900963 ArcaneD 5
125900964 ArcaneD 6
125900965 ArcaneD 7
125900966 ArcaneD 8
125900967 ArcaneD 9
128602204 Int 1
128602205 Int 2
128602206 Int 3
128602207 Int 4
128602208 Int 5
128602209 Int 6
128602210 Int 7
128602211 Int 8
128602212 Int 9
129835490 Dex 9 Secondary
132969381 MF II
132969394 MF IV
132969396 MF IX
132969810 MF VI
132969876 MF XI
137334865 DR 3 Secondary
138948793 REQ 1
138948794 REQ 2
138948795 REQ 3
138948796 REQ 4
138948797 REQ 5
138948798 REQ 6
138948799 REQ 7
138948800 REQ 8
138948801 REQ 9
139520518 Run 1
139520519 Run 2
139520520 Run 3
139520521 Run 4
139520522 Run 5
140674858 Str 1
140674859 Str 2
140674860 Str 3
140674861 Str 4
140674862 Str 5
140674863 Str 6
140674864 Str 7
140674865 Str 8
140674866 Str 9
143839492 Vit 1
143839493 Vit 2
143839494 Vit 3
143839495 Vit 4
143839496 Vit 5
143839497 Vit 6
143839498 Vit 7
143839499 Vit 8
143839500 Vit 9
145064108 DamageVsElite 1
145064109 DamageVsElite 2
145064110 DamageVsElite 3
145064111 DamageVsElite 4
145064112 DamageVsElite 5
145064113 DamageVsElite 6
145064114 DamageVsElite 7
145064115 DamageVsElite 8
145064116 DamageVsElite 9
146989121 PrimaryAttribute_Str 6 Legendary
148767698 DamageBonusHoly 5 Legendary
149318839 DamageReductionArcane 10
149318840 DamageReductionArcane 11
149318841 DamageReductionArcane 12
177212818 Str 1 Secondary
177380668 DamageBonusLightning 7 Legendary
182509027 AllStats1H 16 Legendary
190334883 WeaponHitStun1h 1
190334884 WeaponHitStun1h 2
190334885 WeaponHitStun1h 3
190334886 WeaponHitStun1h 4
190334887 WeaponHitStun1h 5
190334888 WeaponHitStun1h 6
190334889 WeaponHitStun1h 7
190334890 WeaponHitStun1h 8
190334891 WeaponHitStun1h 9
190370820 WeaponHitStun2h 1
190370821 WeaponHitStun2h 2
190370822 WeaponHitStun2h 3
190370823 WeaponHitStun2h 4
190370824 WeaponHitStun2h 5
190370825 WeaponHitStun2h 6
190370826 WeaponHitStun2h 7
190370827 WeaponHitStun2h 8
190370828 WeaponHitStun2h 9
196995670 ArcaneResist II
196995683 ArcaneResist IV
196995685 ArcaneResist IX
196996099 ArcaneResist VI
196996165 ArcaneResist XI
203310911 CriticalD VII Secondary
206301572 Str 12 Secondary
213859622 DexVit XII Secondary
216128063 DamageBonusArcane 4 Legendary
216570352 MaxArcanePower 8 Legendary
217763070 MaxDiscipline 9 Legendary
222340195 StrDex IX Secondary
232497746 Regen 9 Secondary
234233462 CriticalChance IX Secondary
234326221 PoisonD 1
234326222 PoisonD 2
234326223 PoisonD 3
234326224 PoisonD 4
234326225 PoisonD 5
234326226 PoisonD 6
234326227 PoisonD 7
234326228 PoisonD 8
234326229 PoisonD 9
234554942 Inferior Armor Def 0
234554943 Inferior Armor Def 1
234554944 Inferior Armor Def 2
234554945 Inferior Armor Def 3
257744101 DamageReductionPoison 10
257744102 DamageReductionPoison 11
257744103 DamageReductionPoison 12
266872652 Int 9 Secondary
269675659 StrInt IV Secondary
271373080 MinMaxDam 4 Secondary
272282932 HitFear 1
272282933 HitFear 2
272282934 HitFear 3
272282935 HitFear 4
272282936 HitFear 5
272282937 HitFear 6
272282938 HitFear 7
272282939 HitFear 8
272282940 HitFear 9
275241175 Skill_Wizard_ArcaneTorrent 1
275241176 Skill_Wizard_ArcaneTorrent 2
275241177 Skill_Wizard_ArcaneTorrent 3
275241178 Skill_Wizard_ArcaneTorrent 4
275241179 Skill_Wizard_ArcaneTorrent 5
275241180 Skill_Wizard_ArcaneTorrent 6
275241181 Skill_Wizard_ArcaneTorrent 7
275241182 Skill_Wizard_ArcaneTorrent 8
290342921 REQ 10
290342922 REQ 11
290342923 REQ 12
290342924 REQ 13
290342925 REQ 14
290342926 REQ 15
290342927 REQ 16
290342928 REQ 17
290342929 REQ 18
290342930 REQ 19
293363245 DamageBonusPoison 4 Legendary
295151359 MinDam 10 Secondary
295346955 HitSlow 10
295346956 HitSlow 11
295346957 HitSlow 12
295398082 Regen 18 Secondary
296723815 IntVit I
296723828 IntVit V
296723830 IntVit X
298027927 CriticalChance 0.1 Legendary
303782510 Vit 3 Secondary
313317262 Skill_Barbarian_Frenzy 1
313317263 Skill_Barbarian_Frenzy 2
313317264 Skill_Barbarian_Frenzy 3
313317265 Skill_Barbarian_Frenzy 4
313317266 Skill_Barbarian_Frenzy 5
313317267 Skill_Barbarian_Frenzy 6
313317268 Skill_Barbarian_Frenzy 7
313317269 Skill_Barbarian_Frenzy 8
317258451 DR 5 Secondary
320616436 Superior Weapon 1
320616437 Superior Weapon 2
320616438 Superior Weapon 3
320616439 Superior Weapon 4
320616440 Superior Weapon 5
320616441 Superior Weapon 6
320616442 Superior Weapon 7
320765836 Defense II
320765849 Defense IV
320766265 Defense VI
326912707 PrimaryAttribute_Str 8 Legendary
328691284 DamageBonusHoly 7 Legendary
332620933 Sockets Chest II
332620946 Sockets Chest IV
338507747 StrDex I
338507760 StrDex V
338507762 StrDex X
344756429 StrInt I
344756442 StrInt V
344756444 StrInt X
347303066 Str 10
347303067 Str 11
347303068 Str 12
347303069 Str 13
347303070 Str 14
347303071 Str 15
347303072 Str 16
357136404 Str 3 Secondary
357304254 DamageBonusLightning 9 Legendary
359412638 Skill_Wizard_Electrocute 1
359412639 Skill_Wizard_Electrocute 2
359412640 Skill_Wizard_Electrocute 3
359412641 Skill_Wizard_Electrocute 4
359412642 Skill_Wizard_Electrocute 5
359412643 Skill_Wizard_Electrocute 6
359412644 Skill_Wizard_Electrocute 7
359412645 Skill_Wizard_Electrocute 8
359993717 StrVit I
359993730 StrVit V
359993732 StrVit X
360387276 DamageBonusArcane 10 Legendary
364611845 StrVit VIII Secondary
381047567 ResistRoot 1
386225158 Str 14 Secondary
395402212 HitFear 10
395402213 HitFear 11
395402214 HitFear 12
396051649 DamageBonusArcane 6 Legendary
404970487 LightningD 10 Fast
411344938 HealthGlobeChance I
426321653 ResistStun 1
426603890 Vanish I
442649720 Skill_WitchDoctor_Haunt 1
442649721 Skill_WitchDoctor_Haunt 2
442649722 Skill_WitchDoctor_Haunt 3
442649723 Skill_WitchDoctor_Haunt 4
442649724 Skill_WitchDoctor_Haunt 5
442649725 Skill_WitchDoctor_Haunt 6
442649726 Skill_WitchDoctor_Haunt 7
442649727 Skill_WitchDoctor_Haunt 8
444105880 LightningD 11 Fast
448775231 HitLife 2 Secondary
449599245 StrInt IX Secondary
451296666 MinMaxDam 6 Secondary
451735988 Vit 10
451735989 Vit 11
451735990 Vit 12
451735991 Vit 13
451735992 Vit 14
451735993 Vit 15
451735994 Vit 16
452974914 Energize I
453618049 Skill_Wizard_Blizzard 1
453618050 Skill_Wizard_Blizzard 2
453618051 Skill_Wizard_Blizzard 3
453618052 Skill_Wizard_Blizzard 4
453618053 Skill_Wizard_Blizzard 5
453618054 Skill_Wizard_Blizzard 6
453618055 Skill_Wizard_Blizzard 7
453618056 Skill_Wizard_Blizzard 8
454327875 StrDex XI Secondary
473286831 DamageBonusPoison 6 Legendary
475074945 MinDam 12 Secondary
482816586 Dex 10 Secondary
483241273 LightningD 12 Fast
483706096 Vit 5 Secondary
492148316 DamageVsElite 10
492148317 DamageVsElite 11
492148318 DamageVsElite 12
493655914 WeaponHitFreeze1h 10
493655915 WeaponHitFreeze1h 11
493655916 WeaponHitFreeze1h 12
493718975 ManaRegen 1
493718976 ManaRegen 2
493718977 ManaRegen 3
493718978 ManaRegen 4
493718979 ManaRegen 5
493718980 ManaRegen 6
493718981 ManaRegen 7
493718982 ManaRegen 8
493718983 ManaRegen 9
494841835 WeaponHitFreeze2h 10
494841836 WeaponHitFreeze2h 11
494841837 WeaponHitFreeze2h 12
497182037 DR 7 Secondary
503144925 Vit 11 Secondary
504326587 FireResist III
504340744 FireResist VII
504342922 FireResist XII
506750119 ColdResist 0.2 Legendary
508614870 DamageBonusHoly 9 Legendary
509760234 Skill_DemonHunter_SpikeTrap 1
509760235 Skill_DemonHunter_SpikeTrap 2
509760236 Skill_DemonHunter_SpikeTrap 3
509760237 Skill_DemonHunter_SpikeTrap 4
509760238 Skill_DemonHunter_SpikeTrap 5
509760239 Skill_DemonHunter_SpikeTrap 6
509760240 Skill_DemonHunter_SpikeTrap 7
509760241 Skill_DemonHunter_SpikeTrap 8
512004502 HitLife 1
512004503 HitLife 2
512004504 HitLife 3
512004505 HitLife 4
512004506 HitLife 5
512004507 HitLife 6
512004508 HitLife 7
512004509 HitLife 8
512004510 HitLife 9
515844156 Skill_DemonHunter_Strafe 1
515844157 Skill_DemonHunter_Strafe 2
515844158 Skill_DemonHunter_Strafe 3
515844159 Skill_DemonHunter_Strafe 4
515844160 Skill_DemonHunter_Strafe 5
515844161 Skill_DemonHunter_Strafe 6
515844162 Skill_DemonHunter_Strafe 7
515844163 Skill_DemonHunter_Strafe 8
517660244 Sockets Bracer I
517660257 Sockets Bracer V
522376666 LightningD 13 Fast
537059990 Str 5 Secondary
540310862 DamageBonusArcane 12 Legendary
541935667 HitMana 1
541935668 HitMana 2
541935669 HitMana 3
541935670 HitMana 4
541935671 HitMana 5
541935672 HitMana 6
541935673 HitMana 7
541935674 HitMana 8
541935675 HitMana 9
544496523 Bandage I
547881087 Sockets Amulet III
561512059 LightningD 14 Fast
566148744 Str 16 Secondary
570438045 StrVit I Secondary
575975235 DamageBonusArcane 8 Legendary
575982069 Skill_Wizard_SpectralBlade 1
575982070 Skill_Wizard_SpectralBlade 2
575982071 Skill_Wizard_SpectralBlade 3
575982072 Skill_Wizard_SpectralBlade 4
575982073 Skill_Wizard_SpectralBlade 5
575982074 Skill_Wizard_SpectralBlade 6
575982075 Skill_Wizard_SpectralBlade 7
575982076 Skill_Wizard_SpectralBlade 8
597015769 MaxDam 10
597015770 MaxDam 11
597015771 MaxDam 12
597015772 MaxDam 13
597015773 MaxDam 14
599686152 DamageBonusFire 10 Legendary
603032198 MaxDiscipline 10 Legendary
615222192 HitStun 10
615222193 HitStun 11
615222194 HitStun 12
616601423 StrVit III Secondary
625826753 Empathy I
628698817 HitLife 4 Secondary
629174643 DamageReductionFire 10
629174644 DamageReductionFire 11
629174645 DamageReductionFire 12
631220252 MinMaxDam 8 Secondary
632878566 Bleed 11 Secondary
634863971 DefenseMelee 10
634863972 DefenseMelee 11
634863973 DefenseMelee 12
653210417 DamageBonusPoison 8 Legendary
653297373 StrVit VIII
654814437 IntVit IV Secondary
654998531 MinDam 14 Secondary
662740172 Dex 12 Secondary
663629682 Vit 7 Secondary
664607876 Gold V Secondary
664916631 Skill_Monk_SweepingWind 1
664916632 Skill_Monk_SweepingWind 2
664916633 Skill_Monk_SweepingWind 3
664916634 Skill_Monk_SweepingWind 4
664916635 Skill_Monk_SweepingWind 5
664916636 Skill_Monk_SweepingWind 6
664916637 Skill_Monk_SweepingWind 7
664916638 Skill_Monk_SweepingWind 8
665210158 AllStats1H 2 Legendary
669900069 MinMaxDam 10 Secondary
672863894 Skill_WitchDoctor_WallofZombies 1
672863895 Skill_WitchDoctor_WallofZombies 2
672863896 Skill_WitchDoctor_WallofZombies 3
672863897 Skill_WitchDoctor_WallofZombies 4
672863898 Skill_WitchDoctor_WallofZombies 5
672863899 Skill_WitchDoctor_WallofZombies 6
672863900 Skill_WitchDoctor_WallofZombies 7
672863901 Skill_WitchDoctor_WallofZombies 8
677105623 DR 9 Secondary
680767957 DamageVsMonsterTypeHuman 0.1 Legendary
681586925 StrInt XI Secondary
683068511 Vit 13 Secondary
683475831 Thorns 1 Secondary
684907330 Skill_Wizard_Disintegrate 1
684907331 Skill_Wizard_Disintegrate 2
684907332 Skill_Wizard_Disintegrate 3
684907333 Skill_Wizard_Disintegrate 4
684907334 Skill_Wizard_Disintegrate 5
684907335 Skill_Wizard_Disintegrate 6
684907336 Skill_Wizard_Disintegrate 7
684907337 Skill_Wizard_Disintegrate 8
696647397 Kings I
696647410 Kings V
699281021 MaxFury 1
699281022 MaxFury 2
699281023 MaxFury 3
699281024 MaxFury 4
699281025 MaxFury 5
699281026 MaxFury 6
699281027 MaxFury 7
699281028 MaxFury 8
699281029 MaxFury 9
704007875 HitMana 10
704007876 HitMana 11
704007877 HitMana 12
706051672 MaxFury 1 Legendary
707257837 PoisonResist III
707271994 PoisonResist VII
707274172 PoisonResist XII
710075636 Int 10 Secondary
710473498 Superior Armor Def 1
710473499 Superior Armor Def 2
710473500 Superior Armor Def 3
710473501 Superior Armor Def 4
710473502 Superior Armor Def 5
710473503 Superior Armor Def 6
716983576 Str 7 Secondary
719299173 DamageBonusCold 11 Legendary
720915898 MF VI Secondary
727316613 DamageVsElite 11 Secondary
729819747 DamConversionHeal 1
729819748 DamConversionHeal 2
729819749 DamConversionHeal 3
729819750 DamConversionHeal 4
729819751 DamConversionHeal 5
729819752 DamConversionHeal 6
729819753 DamConversionHeal 7
729819754 DamConversionHeal 8
729819755 DamConversionHeal 9
731258444 PrimaryAttribute_Str 10 Legendary
731640128 CriticalD I Secondary
747901660 StrVit VII Secondary
764648506 Skill_WitchDoctor_ZombieCharger 1
764648507 Skill_WitchDoctor_ZombieCharger 2
764648508 Skill_WitchDoctor_ZombieCharger 3
764648509 Skill_WitchDoctor_ZombieCharger 4
764648510 Skill_WitchDoctor_ZombieCharger 5
764648511 Skill_WitchDoctor_ZombieCharger 6
764648512 Skill_WitchDoctor_ZombieCharger 7
764648513 Skill_WitchDoctor_ZombieCharger 8
767021757 StrDex III Secondary
774304239 DexInt III Secondary
779609738 DamageBonusFire 12 Legendary
781591904 Skill_WitchDoctor_AcidCloud 1
781591905 Skill_WitchDoctor_AcidCloud 2
781591906 Skill_WitchDoctor_AcidCloud 3
781591907 Skill_WitchDoctor_AcidCloud 4
781591908 Skill_WitchDoctor_AcidCloud 5
781591909 Skill_WitchDoctor_AcidCloud 6
781591910 Skill_WitchDoctor_AcidCloud 7
781591911 Skill_WitchDoctor_AcidCloud 8
783288591 DamageVsMonsterTypeDemon 0.1 Legendary
789853051 HitSlow 1
789853052 HitSlow 2
789853053 HitSlow 3
789853054 HitSlow 4
789853055 HitSlow 5
789853056 HitSlow 6
789853057 HitSlow 7
789853058 HitSlow 8
789853059 HitSlow 9
792155943 MaxDam 10 Fast
799546240 HitStun 1
799546241 HitStun 2
799546242 HitStun 3
799546243 HitStun 4
799546244 HitStun 5
799546245 HitStun 6
799546246 HitStun 7
799546247 HitStun 8
799546248 HitStun 9
803429398 Bleed 2 Secondary
803501883 Skill_Monk_FistsofThunder 1
803501884 Skill_Monk_FistsofThunder 2
803501885 Skill_Monk_FistsofThunder 3
803501886 Skill_Monk_FistsofThunder 4
803501887 Skill_Monk_FistsofThunder 5
803501888 Skill_Monk_FistsofThunder 6
803501889 Skill_Monk_FistsofThunder 7
803501890 Skill_Monk_FistsofThunder 8
806291157 DamageVsElite 2 Secondary
808622403 HitLife 6 Secondary
810509126 Haste 1
810509127 Haste 2
810509128 Haste 3
810509129 Haste 4
810509130 Haste 5
810509131 Haste 6
810509132 Haste 7
810509133 Haste 8
810509134 Haste 9
823540435 DexInt IV Secondary
831291336 MaxDam 11 Fast
834738023 IntVit IX Secondary
841030311 Skill_WitchDoctor_SpiritBarrage 1
841030312 Skill_WitchDoctor_SpiritBarrage 2
841030313 Skill_WitchDoctor_SpiritBarrage 3
841030314 Skill_WitchDoctor_SpiritBarrage 4
841030315 Skill_WitchDoctor_SpiritBarrage 5
841030316 Skill_WitchDoctor_SpiritBarrage 6
841030317 Skill_WitchDoctor_SpiritBarrage 7
841030318 Skill_WitchDoctor_SpiritBarrage 8
842663758 Dex 14 Secondary
843553268 Vit 9 Secondary
844531462 Gold X Secondary
845133744 AllStats1H 4 Legendary
847944519 MinDam 1
847944520 MinDam 2
847944521 MinDam 3
847944522 MinDam 4
847944523 MinDam 5
847944524 MinDam 6
847944525 MinDam 7
847944526 MinDam 8
847944527 MinDam 9
849823655 MinMaxDam 12 Secondary
851626427 DamageBonusPoison 11 Legendary
854826512 WeaponHitKnockback1h 10
854826513 WeaponHitKnockback1h 11
854826514 WeaponHitKnockback1h 12
856012433 WeaponHitKnockback2h 10
856012434 WeaponHitKnockback2h 11
856012435 WeaponHitKnockback2h 12
862992097 Vit 15 Secondary
863399417 Thorns 3 Secondary
864939483 Life III
864953640 Life VII
865446356 DamageBonusCold 1 Legendary
870426729 MaxDam 12 Fast
885975258 MaxFury 3 Legendary
889667027 StrVit VI Secondary
889999222 Int 12 Secondary
892117988 DamageVsMonsterTypeUndead 10
892117989 DamageVsMonsterTypeUndead 11
892117990 DamageVsMonsterTypeUndead 12
892842485 KillLife 10 Secondary
896907162 Str 9 Secondary
898284862 CriticalChance I Secondary
898321994 StrDex VII Secondary
898909407 Thorns 10
898909408 Thorns 11
898909409 Thorns 12
898909410 Thorns 13
898909411 Thorns 14
898909412 Thorns 15
900666206 Superior Weapon Crit Dmg 1
900666207 Superior Weapon Crit Dmg 2
900666208 Superior Weapon Crit Dmg 3
900666209 Superior Weapon Crit Dmg 4
900666210 Superior Weapon Crit Dmg 5
900666211 Superior Weapon Crit Dmg 6
905604476 DexInt VII Secondary
909562122 MaxDam 13 Fast
911182030 PrimaryAttribute_Str 12 Legendary
912923974 DamageBonusLightning 10 Legendary
918698733 Sockets VIII
918770607 Sockets XIII
918784764 Sockets XVII
929623096 DamageBonusFire 1 Legendary
942725730 HitChill 1
942725731 HitChill 2
942725732 HitChill 3
942725733 HitChill 4
942725734 HitChill 5
942725735 HitChill 6
942725736 HitChill 7
942725737 HitChill 8
942725738 HitChill 9
948697515 MaxDam 14 Fast
949340468 MaxMana 1
949340469 MaxMana 2
949340470 MaxMana 3
949340471 MaxMana 4
949340472 MaxMana 5
949340473 MaxMana 6
949340474 MaxMana 7
949340475 MaxMana 8
949340476 MaxMana 9
968632053 AllStats 2 Legendary
976997430 Haste 10
982068194 Regen 1
982068195 Regen 2
982068196 Regen 3
982068197 Regen 4
982068198 Regen 5
982068199 Regen 6
982068200 Regen 7
982068201 Regen 8
982068202 Regen 9
983352984 Bleed 4 Secondary
986214743 DamageVsElite 4 Secondary
988545989 HitLife 8 Secondary
1003464021 DexInt IX Secondary
1009690905 IntVit III
1009705062 IntVit VII
1009707240 IntVit XII
1015273642 Skill_Barbarian_SeismicSlam 1
1015273643 Skill_Barbarian_SeismicSlam 2
1015273644 Skill_Barbarian_SeismicSlam 3
1015273645 Skill_Barbarian_SeismicSlam 4
1015273646 Skill_Barbarian_SeismicSlam 5
1015273647 Skill_Barbarian_SeismicSlam 6
1015273648 Skill_Barbarian_SeismicSlam 7
1015273649 Skill_Barbarian_SeismicSlam 8
1020396948 StrDex II Secondary
1022587344 Dex 16 Secondary
1025057330 AllStats1H 6 Legendary
1029747241 MinMaxDam 14 Secondary
1032290215 CriticalChance II Secondary
1033515571 StrDex VIII Secondary
1043323003 Thorns 5 Secondary
1045178066 HitChill 10
1045178067 HitChill 11
1045178068 HitChill 12
1045369942 DamageBonusCold 3 Legendary
1048744919 MaxDam 1 Fast
1051283612 Sockets Chest I
1051283625 Sockets Chest V
1055553278 UnknownPrefix
1065726212 AllStats 10 Legendary
1065898844 MaxFury 5 Legendary
1066725703 IntVit XI Secondary
1069922808 Int 14 Secondary
1072766071 KillLife 12 Secondary
1077592132 PrimaryAttribute_Dex 1 Legendary
1079074877 HitKnockback 1
1079074878 HitKnockback 2
1079074879 HitKnockback 3
1079074880 HitKnockback 4
1079074881 HitKnockback 5
1079074882 HitKnockback 6
1079074883 HitKnockback 7
1079074884 HitKnockback 8
1079074885 HitKnockback 9
1087880312 MaxDam 2 Fast
1091105616 PrimaryAttribute_Str 14 Legendary
1091293510 Sockets Bracer III
1092847560 DamageBonusLightning 12 Legendary
1096136612 Skill_DemonHunter_ClusterArrow 1
1096136613 Skill_DemonHunter_ClusterArrow 2
1096136614 Skill_DemonHunter_ClusterArrow 3
1096136615 Skill_DemonHunter_ClusterArrow 4
1096136616 Skill_DemonHunter_ClusterArrow 5
1096136617 Skill_DemonHunter_ClusterArrow 6
1096136618 Skill_DemonHunter_ClusterArrow 7
1096136619 Skill_DemonHunter_ClusterArrow 8
1100381446 CriticalChance VIII Secondary
1109546682 DamageBonusFire 3 Legendary
1109856348 IntVit V Secondary
1118583954 Life 0.1 Secondary Legendary
1123372805 FurySetPoint I
1127015705 MaxDam 3 Fast
1134957745 MaxDam 1 Secondary
1148555639 AllStats 4 Legendary
1158568845 Skill_DemonHunter_RapidFire 1
1158568846 Skill_DemonHunter_RapidFire 2
1158568847 Skill_DemonHunter_RapidFire 3
1158568848 Skill_DemonHunter_RapidFire 4
1158568849 Skill_DemonHunter_RapidFire 5
1158568850 Skill_DemonHunter_RapidFire 6
1158568851 Skill_DemonHunter_RapidFire 7
1158568852 Skill_DemonHunter_RapidFire 8
1159499568 CriticalChance III Secondary
1163276570 Bleed 6 Secondary
1166138329 DamageVsElite 6 Secondary
1166151098 MaxDam 4 Fast
1170633957 Block 2 Secondary
1176553157 UnknownSuffix
1187697044 PrimaryAttribute_Dex 10 Legendary
1191137447 StrVit III
1191151604 StrVit VII
1191153782 StrVit XII
1201951408 IntVit II

1201951421 IntVit IV
1201951423 IntVit IX
1201951837 IntVit VI
1201951903 IntVit XI
1204980916 AllStats1H 8 Legendary
1205286491 MaxDam 5 Fast
1214629294 PrimaryAttribute_Int 1 Legendary
1216368989 CCReduction 0.1 Legendary
1220289425 Experience I
1220289438 Experience V
1220289440 Experience X
1223187383 HealthGlobeBonus 1
1223187384 HealthGlobeBonus 2
1223187385 HealthGlobeBonus 3
1223187386 HealthGlobeBonus 4
1223187387 HealthGlobeBonus 5
1223187388 HealthGlobeBonus 6
1223187389 HealthGlobeBonus 7
1223187390 HealthGlobeBonus 8
1223187391 HealthGlobeBonus 9
1223246589 Thorns 7 Secondary
1225293528 DamageBonusCold 5 Legendary
1225692336 Superior Weapon MinDmg 1
1225692337 Superior Weapon MinDmg 2
1225692338 Superior Weapon MinDmg 3
1225692339 Superior Weapon MinDmg 4
1225692340 Superior Weapon MinDmg 5
1225692341 Superior Weapon MinDmg 6
1230869202 PhysicalResist III
1230883359 PhysicalResist VII
1230885537 PhysicalResist XII
1235451701 DexInt XI Secondary
1244421884 MaxDam 6 Fast
1245649798 AllStats 12 Legendary
1245822430 MaxFury 7 Legendary
1247655998 StrInt II Secondary
1249732621 HitKnockback 10
1249732622 HitKnockback 11
1249732623 HitKnockback 12
1249846394 Int 16 Secondary
1252689657 KillLife 14 Secondary
1257515718 PrimaryAttribute_Dex 3 Legendary
1263464420 MaxMana 10
1264827566 Haste 1 Secondary
1271029202 PrimaryAttribute_Str 16 Legendary
1273837477 DexInt VIII Secondary
1277398927 DamageReductionCold 10
1277398928 DamageReductionCold 11
1277398929 DamageReductionCold 12
1278226092 MF VIII Secondary
1279300849 MF V Secondary
1282026029 DamageVsMonsterTypeUndead 0.1 Legendary
1283538061 ColdResist VIII
1283557277 MaxDam 7 Fast
1285729876 Skill_Wizard_ExplosiveBlast 1
1285729877 Skill_Wizard_ExplosiveBlast 2
1285729878 Skill_Wizard_ExplosiveBlast 3
1285729879 Skill_Wizard_ExplosiveBlast 4
1285729880 Skill_Wizard_ExplosiveBlast 5
1285729881 Skill_Wizard_ExplosiveBlast 6
1285729882 Skill_Wizard_ExplosiveBlast 7
1285729883 Skill_Wizard_ExplosiveBlast 8
1289470268 DamageBonusFire 5 Legendary
1289779934 IntVit X Secondary
1290799805 CriticalChance VII Secondary
1301356130 Indestructible 10
1301356131 Indestructible 11
1301356132 Indestructible 12
1314881331 MaxDam 3 Secondary
1318242209 PhysicalResist 0.1 Legendary
1322692670 MaxDam 8 Fast
1328479225 AllStats 6 Legendary
1337580407 Skill_Wizard_Hydra 1
1337580408 Skill_Wizard_Hydra 2
1337580409 Skill_Wizard_Hydra 3
1337580410 Skill_Wizard_Hydra 4
1337580411 Skill_Wizard_Hydra 5
1337580412 Skill_Wizard_Hydra 6
1337580413 Skill_Wizard_Hydra 7
1337580414 Skill_Wizard_Hydra 8
1340940274 Indestructible 1
1340940275 Indestructible 2
1340940276 Indestructible 3
1340940277 Indestructible 4
1340940278 Indestructible 5
1340940279 Indestructible 6
1340940280 Indestructible 7
1340940281 Indestructible 8
1340940282 Indestructible 9
1343200156 Bleed 8 Secondary
1346061915 DamageVsElite 8 Secondary
1349962976 PhysicalResist I
1349962989 PhysicalResist V
1349962991 PhysicalResist X
1350281777 HolyD 1
1350281778 HolyD 2
1350281779 HolyD 3
1350281780 HolyD 4
1350281781 HolyD 5
1350281782 HolyD 6
1350281783 HolyD 7
1350281784 HolyD 8
1350281785 HolyD 9
1350557543 Block 4 Secondary
1356608766 Sockets Belt III
1361828063 MaxDam 9 Fast
1362861791 DR 10 Secondary
1364262573 ArcaneD 1 Fast
1367620630 PrimaryAttribute_Dex 12 Legendary
1384928025 MaxArcanePower 10 Legendary
1394552880 PrimaryAttribute_Int 3 Legendary
1396292575 CCReduction 0.3 Legendary
1399322748 PoisonResist 0.1 Legendary
1399710566 KillLife 2 Secondary
1402139625 FireD 1 Fast
1403170175 Thorns 9 Secondary
1403397966 ArcaneD 2 Fast
1405217114 DamageBonusCold 7 Legendary
1411990405 ColdD 1 Fast
1414956094 PrimaryAttribute_Int 10 Legendary
1420394115 CriticalD 0.3 Secondary Legendary
1425573384 AllStats 14 Legendary
1425746016 MaxFury 9 Legendary
1432950218 FireResist 0.1 Legendary
1437439304 PrimaryAttribute_Dex 5 Legendary
1441275018 FireD 2 Fast
1441375939 Defense I
1441375952 Defense V
1442533359 ArcaneD 3 Fast
1443531803 DexVit VI Secondary
1444751152 Haste 3 Secondary
1446615034 WeaponHitFreeze1h 1
1446615035 WeaponHitFreeze1h 2
1446615036 WeaponHitFreeze1h 3
1446615037 WeaponHitFreeze1h 4
1446615038 WeaponHitFreeze1h 5
1446615039 WeaponHitFreeze1h 6
1446615040 WeaponHitFreeze1h 7
1446615041 WeaponHitFreeze1h 8
1446615042 WeaponHitFreeze1h 9
1446650971 WeaponHitFreeze2h 1
1446650972 WeaponHitFreeze2h 2
1446650973 WeaponHitFreeze2h 3
1446650974 WeaponHitFreeze2h 4
1446650975 WeaponHitFreeze2h 5
1446650976 WeaponHitFreeze2h 6
1446650977 WeaponHitFreeze2h 7
1446650978 WeaponHitFreeze2h 8
1446650979 WeaponHitFreeze2h 9
1446938386 FireResist II
1446938399 FireResist IV
1446938401 FireResist IX
1446938815 FireResist VI
1446938881 FireResist XI
1447984474 CriticalD 0.2 Legendary
1448701309 DexInt VIII
1451125798 ColdD 2 Fast
1459224435 MF X Secondary
1459807555 Kings VI Secondary
1469393854 DamageBonusFire 7 Legendary
1476560065 CriticalD II
1476560078 CriticalD IV
1476560080 CriticalD IX
1476560494 CriticalD VI
1480410411 FireD 3 Fast
1481668752 ArcaneD 4 Fast
1481841994 CriticalD III
1481856151 CriticalD VII
1490261191 ColdD 3 Fast
1494804917 MaxDam 5 Secondary
1497318476 ResistFreeze 1
1498165795 PhysicalResist 0.3 Legendary
1500725738 Life 0.1 Legendary
1508402811 AllStats 8 Legendary
1514527726 Kings II
1514527739 Kings IV
1514528155 Kings VI
1519545804 FireD 4 Fast
1520804145 ArcaneD 5 Fast
1526210135 WeaponHitFear1h 1
1526210136 WeaponHitFear1h 2
1526210137 WeaponHitFear1h 3
1526210138 WeaponHitFear1h 4
1526210139 WeaponHitFear1h 5
1526210140 WeaponHitFear1h 6
1526210141 WeaponHitFear1h 7
1526210142 WeaponHitFear1h 8
1526210143 WeaponHitFear1h 9
1526246072 WeaponHitFear2h 1
1526246073 WeaponHitFear2h 2
1526246074 WeaponHitFear2h 3
1526246075 WeaponHitFear2h 4
1526246076 WeaponHitFear2h 5
1526246077 WeaponHitFear2h 6
1526246078 WeaponHitFear2h 7
1526246079 WeaponHitFear2h 8
1526246080 WeaponHitFear2h 9
1527600542 CriticalChance VIII
1528764650 HatredRegen 10
1529396584 ColdD 4 Fast
1530481129 Block 6 Secondary
1531537038 ArcaneResist 0.1 Legendary
1534301774 WeaponHitSlow1h 10
1534301775 WeaponHitSlow1h 11
1534301776 WeaponHitSlow1h 12
1535487695 WeaponHitSlow2h 10
1535487696 WeaponHitSlow2h 11
1535487697 WeaponHitSlow2h 12
1542785377 DR 12 Secondary
1547544216 PrimaryAttribute_Dex 14 Legendary
1555987111 HitFreeze 10
1555987112 HitFreeze 11
1555987113 HitFreeze 12
1558681197 FireD 5 Fast
1559939538 ArcaneD 6 Fast
1567189505 MaxDam 10 Secondary
1568531977 ColdD 5 Fast
1574476466 PrimaryAttribute_Int 5 Legendary
1579246334 PoisonResist 0.3 Legendary
1579634152 KillLife 4 Secondary
1581623210 Black Market I
1585140700 DamageBonusCold 9 Legendary
1589045967 Thorns 1
1589045968 Thorns 2
1589045969 Thorns 3
1589045970 Thorns 4
1589045971 Thorns 5
1589045972 Thorns 6
1589045973 Thorns 7
1589045974 Thorns 8
1589045975 Thorns 9
1594879680 PrimaryAttribute_Int 12 Legendary
1597816590 FireD 6 Fast
1599074931 ArcaneD 7 Fast
1599105353 PhysicalResist II
1599105366 PhysicalResist IV
1599105368 PhysicalResist IX
1599105782 PhysicalResist VI
1599105848 PhysicalResist XI
1601437261 MaxFury 10
1605496970 AllStats 16 Legendary
1606106763 StrDex VIII
1607667370 ColdD 6 Fast
1609625729 HolyD 10
1609625730 HolyD 11
1609625731 HolyD 12
1609625732 HolyD 13
1609625733 HolyD 14
1611207006 DamageBonusHoly 10 Legendary
1612873804 FireResist 0.3 Legendary
1614845466 Experience II
1614845479 Experience IV
1614845481 Experience IX
1614845895 Experience VI
1614845961 Experience XI
1616088365 MinMaxDam 1
1616088366 MinMaxDam 2
1616088367 MinMaxDam 3
1616088368 MinMaxDam 4
1616088369 MinMaxDam 5
1616088370 MinMaxDam 6
1616088371 MinMaxDam 7
1616088372 MinMaxDam 8
1616088373 MinMaxDam 9
1617013231 MinDam 1 Secondary
1617362890 PrimaryAttribute_Dex 7 Legendary
1620834582 DamageVsMonsterTypeDemon 1
1620834583 DamageVsMonsterTypeDemon 2
1620834584 DamageVsMonsterTypeDemon 3
1620834585 DamageVsMonsterTypeDemon 4
1620834586 DamageVsMonsterTypeDemon 5
1620834587 DamageVsMonsterTypeDemon 6
1620834588 DamageVsMonsterTypeDemon 7
1620834589 DamageVsMonsterTypeDemon 8
1620834590 DamageVsMonsterTypeDemon 9
1624674738 Haste 5 Secondary
1632794776 IntVit II Secondary
1636951983 FireD 7 Fast
1638210324 ArcaneD 8 Fast
1642588215 Gold I Secondary
1646802763 ColdD 7 Fast
1647586587 Dex 2 Secondary
1649317440 DamageBonusFire 9 Legendary
1656612832 CriticalD VIII
1674728503 MaxDam 7 Secondary
1676087376 FireD 8 Fast
1677345717 ArcaneD 9 Fast
1680649324 Life 0.3 Legendary
1685938156 ColdD 8 Fast
1687764647 LightningD 1 Fast
1691963212 DamReductionVsElite 1
1691963213 DamReductionVsElite 2
1691963214 DamReductionVsElite 3
1691963215 DamReductionVsElite 4
1691963216 DamReductionVsElite 5
1691963217 DamReductionVsElite 6
1691963218 DamReductionVsElite 7
1691963219 DamReductionVsElite 8
1691963220 DamReductionVsElite 9
1692679445 WeaponHitChill1h 10
1692679446 WeaponHitChill1h 11
1692679447 WeaponHitChill1h 12
1693865366 WeaponHitChill2h 10
1693865367 WeaponHitChill2h 11
1693865368 WeaponHitChill2h 12
1710404715 Block 8 Secondary
1710478023 HealthGlobeBonus 10
1710478024 HealthGlobeBonus 11
1710478025 HealthGlobeBonus 12
1711460624 ArcaneResist 0.3 Legendary
1714269847 DexVit III Secondary
1715222769 FireD 9 Fast
1722708963 DR 14 Secondary
1725073549 ColdD 9 Fast
1726900040 LightningD 2 Fast
1727467802 PrimaryAttribute_Dex 16 Legendary
1734321449 MaxArcanePower 1 Legendary
1735514167 MaxDiscipline 2 Legendary
1740200688 Protection I
1747113091 MaxDam 12 Secondary
1750248843 Regen 2 Secondary
1750292931 Experience III
1750307088 Experience VII
1750309266 Experience XII
1754400052 PrimaryAttribute_Int 7 Legendary
1759557738 KillLife 6 Secondary
1766035433 LightningD 3 Fast
1772014126 ColdResist II
1772014139 ColdResist IV
1772014141 ColdResist IX
1772014555 ColdResist VI
1772014621 ColdResist XI
1774803266 PrimaryAttribute_Int 14 Legendary
1777599999 StrInt III
1777614156 StrInt VII
1777616334 StrInt XII
1784623749 Int 2 Secondary
1790633672 Thorns 11 Secondary
1791130592 DamageBonusHoly 12 Legendary
1791308541 MinMaxDam 10
1791308542 MinMaxDam 11
1791308543 MinMaxDam 12
1791308544 MinMaxDam 13
1791308545 MinMaxDam 14
1791554649 LightningD 1
1791554650 LightningD 2
1791554651 LightningD 3
1791554652 LightningD 4
1791554653 LightningD 5
1791554654 LightningD 6
1791554655 LightningD 7
1791554656 LightningD 8
1791554657 LightningD 9
1796936817 MinDam 3 Secondary
1797286476 PrimaryAttribute_Dex 9 Legendary
1801520774 DexInt II Secondary
1803327510 Skill_Wizard_MagicMissile 1
1803327511 Skill_Wizard_MagicMissile 2
1803327512 Skill_Wizard_MagicMissile 3
1803327513 Skill_Wizard_MagicMissile 4
1803327514 Skill_Wizard_MagicMissile 5
1803327515 Skill_Wizard_MagicMissile 6
1803327516 Skill_Wizard_MagicMissile 7
1803327517 Skill_Wizard_MagicMissile 8
1804598324 Haste 7 Secondary
1805170826 LightningD 4 Fast
1811763752 MaxFury 10 Legendary
1813149179 Regen 11 Secondary
1814192943 HitLife 11 Secondary
1827510173 Dex 4 Secondary
1844306219 LightningD 5 Fast
1844663804 PrimaryAttribute_Str 1 Legendary
1845570084 DexVit VII Secondary
1853617543 Life VI Secondary
1854652089 MaxDam 9 Secondary
1865139427 PoisonResist VIII
1875055351 DamageBonusLightning 2 Legendary
1880183710 AllStats1H 11 Legendary
1883441612 LightningD 6 Fast
1902632549 DR 16 Secondary
1905952666 Damage III
1905966823 Damage VII
1909249930 WeaponHitImmobilize1h 1
1909249931 WeaponHitImmobilize1h 2
1909249932 WeaponHitImmobilize1h 3
1909249933 WeaponHitImmobilize1h 4
1909249934 WeaponHitImmobilize1h 5
1909249935 WeaponHitImmobilize1h 6
1909249936 WeaponHitImmobilize1h 7
1909249937 WeaponHitImmobilize1h 8
1909249938 WeaponHitImmobilize1h 9
1909285867 WeaponHitImmobilize2h 1
1909285868 WeaponHitImmobilize2h 2
1909285869 WeaponHitImmobilize2h 3
1909285870 WeaponHitImmobilize2h 4
1909285871 WeaponHitImmobilize2h 5
1909285872 WeaponHitImmobilize2h 6
1909285873 WeaponHitImmobilize2h 7
1909285874 WeaponHitImmobilize2h 8
1909285875 WeaponHitImmobilize2h 9
1910884269 Gold VI Secondary
1913589057 Gold III
1913603214 Gold VII
1914245035 MaxArcanePower 3 Legendary
1914368470 CriticalD VI Secondary
1915437753 MaxDiscipline 4 Legendary
1918138219 PoisonD 10 Fast
1922577005 LightningD 7 Fast
1925559161 Experience VIII
1927036677 MaxDam 14 Secondary
1930172429 Regen 4 Secondary
1934323638 PrimaryAttribute_Int 9 Legendary
1939481324 KillLife 8 Secondary
1947933702 DamageVsMonsterTypeDemon 10
1947933703 DamageVsMonsterTypeDemon 11
1947933704 DamageVsMonsterTypeDemon 12
1951515674 MF IV Secondary
1951651227 MaxDiscipline 1
1951651228 MaxDiscipline 2
1951651229 MaxDiscipline 3
1951651230 MaxDiscipline 4
1951651231 MaxDiscipline 5
1951651232 MaxDiscipline 6
1951651233 MaxDiscipline 7
1951651234 MaxDiscipline 8
1951651235 MaxDiscipline 9
1954726852 PrimaryAttribute_Int 16 Legendary
1957273612 PoisonD 11 Fast
1961712398 LightningD 8 Fast
1964445288 PhysicalResist VIII
1964547335 Int 4 Secondary
1970557258 Thorns 13 Secondary
1975614494 ResistAll 0.2 Legendary
1976860403 MinDam 5 Secondary
1978468146 Life II
1978468159 Life IV
1978468161 Life IX
1978468575 Life VI
1978556068 LifeS 1
1978556069 LifeS 2
1978556070 LifeS 3
1978556071 LifeS 4
1978556072 LifeS 5
1978556073 LifeS 6
1978556074 LifeS 7
1986083891 WeaponHitStun1h 10
1986083892 WeaponHitStun1h 11
1986083893 WeaponHitStun1h 12
1987269812 WeaponHitStun2h 10
1987269813 WeaponHitStun2h 11
1987269814 WeaponHitStun2h 12
1993072765 Regen 13 Secondary
1994116529 HitLife 13 Secondary
1995338101 Defense III
1995352258 Defense VII
1996409005 PoisonD 12 Fast
2000847791 LightningD 9 Fast
2007433759 Dex 6 Secondary
2024587390 PrimaryAttribute_Str 3 Legendary
2026365967 DamageBonusHoly 2 Legendary
2035544398 PoisonD 13 Fast
2044719016 Damage I
2044719029 Damage V
2048824082 Multishot I
2054978937 DamageBonusLightning 4 Legendary
2060107296 AllStats1H 13 Legendary
2064982189 Bleed 1
2064982190 Bleed 2
2064982191 Bleed 3
2064982192 Bleed 4
2064982193 Bleed 5
2064982194 Bleed 6
2064982195 Bleed 7
2064982196 Bleed 8
2064982197 Bleed 9
2074679791 PoisonD 14 Fast
2076777148 Block 1
2076777149 Block 2
2076777150 Block 3
2076777151 Block 4
2076777152 Block 5
2076777153 Block 6
2076777154 Block 7
2076777155 Block 8
2076777156 Block 9
2082556135 DR 18 Secondary
2082594650 Kings V Secondary
2087836687 IntVit I Secondary
2093726332 DamageBonusArcane 1 Legendary
2094168621 MaxArcanePower 5 Legendary
2094528286 Life V Secondary
2095361339 MaxDiscipline 6 Legendary
2104949384 Tribute I
2110096015 Regen 6 Secondary
2117266942 MaxArcanePower 10
2120266803 StrVit IV Secondary
2124069787 PoisonD 1 Fast
2128734586 HatredRegen 1
2128734587 HatredRegen 2
2128734588 HatredRegen 3
2128734589 HatredRegen 4
2128734590 HatredRegen 5
2128734591 HatredRegen 6
2128734592 HatredRegen 7
2128734593 HatredRegen 8
2128734594 HatredRegen 9
2130597481 Damage 0.1 Legendary
2131439260 MF IX Secondary
2132551488 Skill_Barbarian_Cleave 1
2132551489 Skill_Barbarian_Cleave 2
2132551490 Skill_Barbarian_Cleave 3
2132551491 Skill_Barbarian_Cleave 4
2132551492 Skill_Barbarian_Cleave 5
2132551493 Skill_Barbarian_Cleave 6
2132551494 Skill_Barbarian_Cleave 7
2132551495 Skill_Barbarian_Cleave 8
2133701701 WeaponHitChill1h 1
2133701702 WeaponHitChill1h 2
2133701703 WeaponHitChill1h 3
2133701704 WeaponHitChill1h 4
2133701705 WeaponHitChill1h 5
2133701706 WeaponHitChill1h 6
2133701707 WeaponHitChill1h 7
2133701708 WeaponHitChill1h 8
2133701709 WeaponHitChill1h 9
2133737638 WeaponHitChill2h 1
2133737639 WeaponHitChill2h 2
2133737640 WeaponHitChill2h 3
2133737641 WeaponHitChill2h 4
2133737642 WeaponHitChill2h 5
2133737643 WeaponHitChill2h 6
2133737644 WeaponHitChill2h 7
2133737645 WeaponHitChill2h 8
2133737646 WeaponHitChill2h 9
2134703545 Life VIII Secondary
2144470921 Int 6 Secondary
2145728258 DamageVsMonsterTypeBeast 10
2145728259 DamageVsMonsterTypeBeast 11
2145728260 DamageVsMonsterTypeBeast 12";

        #endregion

        public Form1()
        {
            InitializeComponent();
            foreach (var line in Affix.Split(new[] {"\n"}, StringSplitOptions.None).Where(line => !string.IsNullOrEmpty(line)))
            {
                Affixes.Add(line.Split(new[] { ' ' }, 2)[0], line.Split(new[] { ' ' }, 2)[1]);
            }
            foreach (var line in URLS.Split(new[] { "\n" }, StringSplitOptions.None).Where(line => !string.IsNullOrEmpty(line)))
            {
                URLDict.Add(line.Split(new[] { ' ' }, 2)[1], line.Split(new[] { ' ' }, 2)[0]);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Split(':').Count() == 18)
            {
                Analyse(textBox1.Text);
            }
        }

        private void Analyse(string raw)
        {
            var data = raw.Split(':');
            data[0] = "|HItem";
            var item = new Item();
            data[9] = (int.Parse(data[9]) | 0x1).ToString();
            var affixes = data[3].Split(',');
            Array.Reverse(affixes);
            data[3] = string.Join(",", affixes);
            item.Affixes = new List<string>();
            foreach (var affix in affixes)
            {
                string aff = "";
                if (Affixes.TryGetValue(affix, out aff))
                    item.Affixes.Add(aff);
            }
            var match = ItemName.Match(data[17]);
            if (match.Success)
                item.Name = match.Groups[1].Value;
            item.MaxDurability = data[11];
            item.CurrentDurability = data[10];
            item.Stack = data[12];
            item.Rarity = (ItemRarity) Int32.Parse(data[14]);
            item.Identified = (Int32.Parse(data[9])%2) != 0;
            var hash_input = "";
            for (int i = 1; i < 16; i++ )
            {
                hash_input += data[i] + ":";
            }
            var hash = HashItem(hash_input);
            data[16] = hash;
            data[17] = string.Format("|h[{{c:{0}}}{1}{{/c}}]|h", GetColour(item.Rarity), item.Name);
            item.Hashed = string.Join(":", data);
            Update(item);
        }

        private void Update(Item item)
        {
            textBox2.Text = item.Name;
            checkBox1.Checked = item.Identified;
            textBox3.Text = string.Join(" ", item.Rarity.ToString().Split('_'));
            textBox4.Text = string.Format("{0}/{1}", item.CurrentDurability, item.MaxDurability);
            textBox5.Text = item.Stack;
            listView1.Items.Clear();
            foreach (var affix in item.Affixes)
            {
                listView1.Items.Add(affix);
            }
            textBox6.Text = item.Hashed;
        }

        private string HashItem(string raw)
        {
            uint h = 0;
            foreach (var cha in raw)
            {
                h = ((h*0x21) << 32) + cha;
            }
            return h.ToString();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var url = "";
                if (URLDict.TryGetValue(listView1.SelectedItems[0].Text, out url))
                {
                    Process.Start(url);
                }
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetDataObject(textBox6.Text);
        }

        private static string GetColour(ItemRarity rare)
        {
            switch (rare)
            {
                case ItemRarity.White:
                    return "ffffffff";
                case ItemRarity.Rare_4_affixes:
                case ItemRarity.Rare_5_affixes:
                case ItemRarity.Rare_6_affixes:
                    return "ffffff00";
                case ItemRarity.LegendarySet_1_affixes:
                case ItemRarity.LegendarySet_2_affixes:
                    return "ffbf642f";
                case ItemRarity.Inferior:
                    return "ff888888";
                case ItemRarity.Magic_2_affixes:
                case ItemRarity.Magic_1_affixes:
                case ItemRarity.Magic_3_affixes:
                    return "ff6969ff";
                default:
                    return "ffffffff";
            }
        }
    }
    class Item
    {
        public List<string> Affixes;
        public string Name;
        public bool Identified;
        public string MaxDurability;
        public string CurrentDurability;
        public ItemRarity Rarity;
        public string Stack;
        public string Hashed;
    }

    enum ItemRarity
    {
        Inferior = 0,
        White = 1,
        Superior = 2,
        Magic_1_affixes = 3,
        Magic_2_affixes = 4,
        Magic_3_affixes = 5,
        Rare_4_affixes = 6,
        Rare_5_affixes = 7,
        Rare_6_affixes = 8,
        LegendarySet_1_affixes = 9,
        LegendarySet_2_affixes = 10
    }
}

