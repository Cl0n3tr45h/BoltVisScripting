using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager
{
    private Skill[] activeSkills;
    public bool isCasting;

    public void AddSkill(Skill skill) {
        if (skill.isAvailable){
           for(int i = 0; i < activeSkills.Length; i++) {
              if(activeSkills[i] == null) {
                 activeSkills[i] = skill;
                 break;
              }
           }
        }
    }

    public void AddSkill(Skill skill, int position) {
        if (skill.isAvailable) {
            activeSkills[position] = skill;
        }
    }

    public void RemoveSkill(Skill skill) {
        for (int i = 0; i < activeSkills.Length; i++) {
            if (activeSkills[i].Equals(skill)) {
                activeSkills[i] = null;
                break;
            }
        }
    }

    public void RemoveSkill(int position) {
        activeSkills[position] = null;
    }

    public void MoveSkill(int start, int target) {
        if(activeSkills[target] != null) {
            Skill swap = activeSkills[target];
            activeSkills[target] = activeSkills[start];
            activeSkills[start] = swap;
        }
        else {
            activeSkills[target] = activeSkills[start];
        }
    }

    public void ActivateSkill(int position) {
        if (!isCasting && activeSkills[position].isAvailable) {
            isCasting = true;
            activeSkills[position].isAvailable = false;
            
            activeSkills[position].TriggerEffect();
        }
    }

    public Skill[] GetAllSkills() {
        return activeSkills;
    }

    public Skill GetSkill(int position) {
        return activeSkills[position];
    }

    public Skill GetLeftSkill(int position, int amount) {
        if (position - amount < 0) {
            return null;
        }
        return activeSkills[position - amount];
    }

    public Skill GetRightSkill(int position, int amount) {
        if(position + amount !< activeSkills.Length) {
            return null;
        }
        return activeSkills[position + amount];
    }

    public Skill GetRandomSkill() {
        return activeSkills[Random.Range(0, activeSkills.Length)];
    }
}
