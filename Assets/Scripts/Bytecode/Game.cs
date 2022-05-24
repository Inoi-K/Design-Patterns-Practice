using UnityEngine;

namespace Bytecode {
    public class Game : MonoBehaviour {

        VM vm;

        Wizard[] wizards = new Wizard[3];

        void OnEnable() {
            vm = new VM(this);

            for (int i = 0; i < wizards.Length; ++i) {
                wizards[i] = new Wizard(
                    Random.Range(1, 7), 
                    Random.Range(1, 7), 
                    Random.Range(1, 7)
                    );
                
                print($"Wizard {i}: [{wizards[i].health}, {wizards[i].wisdom}, {wizards[i].agility}]");
            }
        }

        void Start() {
            int[] bytecode = {
                (int) Instruction.INST_LITERAL, 0,
                (int) Instruction.INST_LITERAL, 0,
                (int) Instruction.INST_GET_HEALTH,
                (int) Instruction.INST_LITERAL, 0,
                (int) Instruction.INST_GET_AGILITY,
                (int) Instruction.INST_LITERAL, 0,
                (int) Instruction.INST_GET_WISDOM,
                (int) Instruction.INST_ADD,
                (int) Instruction.INST_LITERAL, 2,
                (int) Instruction.INST_DIVIDE,
                (int) Instruction.INST_ADD,
                (int) Instruction.INST_SET_HEALTH,
            };

            vm.Interpret(bytecode);
        }

        public void SetHealth(int wizardID, int value) {
            wizards[wizardID].health = value;
            
            print($"Wizard {wizardID}'s health is now {value}");
        }

        public void SetWisdom(int wizardID, int value) {
            wizards[wizardID].wisdom = value;
            
            print($"Wizard {wizardID}'s wisdom is now {value}");
        }

        public void SetAgility(int wizardID, int value) {
            wizards[wizardID].agility = value;
            
            print($"Wizard {wizardID}'s agility is now {value}");
        }

        public int GetHealth(int wizardID) {
            return wizards[wizardID].health;
        }
        
        public int GetWisdom(int wizardID) {
            return wizards[wizardID].wisdom;
        }
        
        public int GetAgility(int wizardID) {
            return wizards[wizardID].agility;
        }
    }
}
