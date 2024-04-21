using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    [SerializeReference]
    private List<Ability> _allAbilities;

    private IInputSource _inputSource;
    private Ability _ability1, _ability2;

    public void Initialize(IInputSource inputSource)
    {
        _inputSource = inputSource;
        _ability1 = _allAbilities[0];
    }

    public void Tick()
    {
        if (_inputSource.IsAbility1Performed && _ability1.CurrentCooldown <= Time.time)
            _ability1.Cast(transform, _inputSource.AimPositon);
        if (_inputSource.IsAbility2Performed && _ability2.CurrentCooldown <= Time.time)
            _ability2.Cast(transform, _inputSource.AimPositon);
    }

    public void SetTestInputSource(IInputSource inputSource) => _inputSource = inputSource;
    public void SetTestAbilitySlots(Ability ability)
    {
        _ability1 = ability;
        _ability2 = ability;
    } 

    [ContextMenu(nameof(AddRapidFireAbility))]
    void AddRapidFireAbility() => _allAbilities.Add(new RapidFireAbility());
}
