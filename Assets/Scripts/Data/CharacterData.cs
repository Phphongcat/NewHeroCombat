using System.Collections.Generic;

namespace Data
{
    [System.Serializable]
    public class CharacterData
    {
        public int atk;
        public int hp;
        public int mp;
        public float hpRegen;
        public float mpRegen;
        public float speed;
        public CharacterType characterType;
    }

    public static class CharacterDataUtil
    {
        public static void FieldDictionary(this CharacterData data,
            out Dictionary<string, object> dictionary)
        {
            dictionary = new Dictionary<string, object>
            {
                [nameof(data.atk)] = data.atk,
                [nameof(data.hp)] = data.hp,
                [nameof(data.mp)] = data.mp,
                [nameof(data.hpRegen)] = data.hpRegen,
                [nameof(data.mpRegen)] = data.mpRegen,
                [nameof(data.speed)] = data.speed,
                [nameof(data.characterType)] = data.characterType,
            };
        }

        public static void Renew(this CharacterData data, Dictionary<string, object> dictionary)
        {
            foreach (var keyValuePair in dictionary) data.Renew(keyValuePair.Key, keyValuePair.Value);
        }

        public static void Renew(this CharacterData data, string id, object stat)
        {
            if (string.IsNullOrEmpty(id)) return;
            switch (id)
            {
                case nameof(data.atk):
                    data.atk = (int)stat;
                    break;
                case nameof(data.hp):
                    data.hp = (int)stat;
                    break;
                case nameof(data.mp):
                    data.mp = (int)stat;
                    break;
                case nameof(data.hpRegen):
                    data.hpRegen = (float)stat;
                    break;
                case nameof(data.mpRegen):
                    data.mpRegen = (float)stat;
                    break;
                case nameof(data.speed):
                    data.speed = (float)stat;
                    break;
                case nameof(data.characterType):
                    data.characterType = (CharacterType)stat;
                    break;
            }
        }

        public static void Renew(this CharacterData data, CharacterData handle)
        {
            data.atk = handle.atk;
            data.hp = handle.hp;
            data.mp = handle.mp;
            data.hpRegen = handle.hpRegen;
            data.mpRegen = handle.mpRegen;
            data.speed = handle.speed;
            data.characterType = handle.characterType;
        }
    }

    public enum CharacterType
    {
        None = 0,
        Player = 1,
        Member = 2,
        Monster = 3,
        Boss = 4
    }
}