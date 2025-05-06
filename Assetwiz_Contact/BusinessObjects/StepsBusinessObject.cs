namespace Assetwiz_Contact.BusinessObjects;
using Assetwiz_Contact.Data;
using Assetwiz_Contact.ViewModels;
using Microsoft.EntityFrameworkCore;

public class StepsBusinessObject
{
    private readonly AppDbContext _context;

    public StepsBusinessObject(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StepsViewModel>> GetAllStepsgAsync()
    {
        return await _context.Steps.ToListAsync();
    }

    public async Task<StepsViewModel?> GetStepsByIdAsync(long id)
    {
        return await _context.Steps.FindAsync(id);
    }

    public async Task<StepsViewModel> AddStepsAsync(StepsViewModel steps)
    {
        steps.CreatedOn = DateTime.UtcNow;
        _context.Steps.Add(steps);
        await _context.SaveChangesAsync();
        return steps;
    }

    public async Task<bool> DeleteStepsAsync(long id)
    {
        var steps = await _context.Steps.FindAsync(id);
        if (steps == null) return false;
        _context.Steps.Remove(steps);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<StepsViewModel?> UpdateStepsAsync(long id, StepsViewModel updatedSteps)
    {
        var existing = await _context.Steps.FindAsync(id);
        if (existing == null) return null;

        existing.StepID = updatedSteps.StepID;
        existing.StepName = updatedSteps.StepName;
        existing.Description = updatedSteps.Description;
        existing.ProcedureID = updatedSteps.ProcedureID;
        existing.OtherInformation = updatedSteps.OtherInformation;
        existing.LocationID = updatedSteps.LocationID;
        existing.LocationName = updatedSteps.LocationName;
        existing.CreatedBy = updatedSteps.CreatedBy;
        existing.CreatedByName = updatedSteps.CreatedByName;
        existing.CreatedOn = updatedSteps.CreatedOn;
        existing.ModifiedBy = updatedSteps.ModifiedBy;
        existing.ModifiedByName = updatedSteps.ModifiedByName;
        existing.ModifiedOn = updatedSteps.ModifiedOn;
        existing.DisplayOrder = updatedSteps.DisplayOrder;
        existing.IsEnabled = updatedSteps.IsEnabled ;

        await _context.SaveChangesAsync();
        return existing;
    }
}
