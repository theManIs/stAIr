using Hub_UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    class Quest
    {
        public int Id;
        public string Name;
        public string Image;
        public string Description;
        public List<QuestVariant> Variants = new List<QuestVariant>();

        static System.Random rnd = new System.Random();

        public QuestResult GenerateResult(QuestVariant variant)
        {
            if (variant.Results.Count == 0)
                return null;

            var sum = (float)variant.Results.Sum(r => r.Probability);

            try
            {
                //choose random result (by probabilities)
                var probs = variant.Results.Select(r => (float)r.Probability).ToList();
                var res = variant.Results.GetRnd(probs, rnd, sum);

                //apply effect
                res.Effect?.Invoke(Player.Instance);

                //return result
                return res;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<QuestVariant> GenerateVariants()
        {
            return Variants.Where(v => v.Condition == null || v.Condition(Player.Instance));
        }
    }

    class QuestVariant
    {
        public Func<Player, bool> Condition;
        public string Description;
        public List<QuestResult> Results = new List<QuestResult>();
    }

    class QuestResult
    {
        /// <summary>Probability % (from 0 to 100)</summary>
        public int Probability = 100;
        public string Description;
        public string EffectDescription;
        public Action<Player> Effect;

        public string FullDescription
        {
            get
            {
                if (string.IsNullOrWhiteSpace(EffectDescription))
                    return Description.Prepare();

                return $"{Description.Prepare()}\n\n<b>{EffectDescription.Prepare()}</b>";
            }
        }
    }
}