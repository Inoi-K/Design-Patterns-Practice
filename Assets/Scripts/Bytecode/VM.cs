using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bytecode {
    public class VM {
        Stack<int> stackMachine = new ();

        Game gm;
        const int MaxStack = 128;

        public VM(Game game) {
            gm = game;
        }
        
        public void Interpret(int[] bytecode) {
            for (int i = 0; i < bytecode.Length; ++i) {
                Instruction instruction = (Instruction) bytecode[i];
                switch (instruction) {
                    case Instruction.INST_SET_HEALTH: {
                        int value = Pop();
                        int wizardID = Pop();
                        gm.SetHealth(wizardID, value);
                        break;
                    }
                    case Instruction.ISNT_SET_WISDOM:{
                        int value = Pop();
                        int wizardID = Pop();
                        gm.SetWisdom(wizardID, value);
                        break;
                    }
                    case Instruction.INST_SET_AGILITY:{
                        int value = Pop();
                        int wizardID = Pop();
                        gm.SetAgility(wizardID, value);
                        break;
                    }
                    /*case Instruction.INST_PLAY_SOUND:
                        break;
                    case Instruction.INST_SPAWN_PARTICLES:
                        break;*/
                    case Instruction.INST_LITERAL:
                        Push(bytecode[++i]);
                        break;
                    case Instruction.INST_GET_HEALTH: {
                        int wizardID = Pop();
                        Push(gm.GetHealth(wizardID));
                        break;
                    }
                    case Instruction.INST_GET_WISDOM: {
                        int wizardID = Pop();
                        Push(gm.GetWisdom(wizardID));
                        break;
                    }
                    case Instruction.INST_GET_AGILITY: {
                        int wizardID = Pop();
                        Push(gm.GetAgility(wizardID));
                        break;
                    }
                    case Instruction.INST_ADD: {
                        int b = Pop();
                        int a = Pop();
                        Push(a + b);
                        break;
                    }
                    case Instruction.INST_DIVIDE: {
                        int b = Pop();
                        int a = Pop();
                        Push(a / b);
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                PrintStack();
            }
        }

        void Push(int value) {
            if (stackMachine.Count >= MaxStack) {
                Debug.LogWarning("Stack overflow");
                return;
            }
        
            stackMachine.Push(value);
        }

        int Pop() {
            if (stackMachine.Count == 0) {
                Debug.LogWarning("Stack is empty");
                return 0;
            }

            return stackMachine.Pop();
        }

        void PrintStack() {
            string info = "[ ";
            foreach (var t in stackMachine) {
                info += $"{t} ";
            }
            info += "]";
            
            Debug.Log(info);
        }
    }
}
