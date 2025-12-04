namespace ToDos.CoreLibrary.Helpers;
public static class Extensions
{
    extension <E>(BasicList<E> list)
        where E: IMasterToDoModel
    {
        public void ChangePriorities()
        {
            // Step 1: Track items that have been manually adjusted (those with EnterStatus == EnumEnterStatus.Changed)
            list.ForEach(thisItem =>
            {
                if (thisItem.Priority.HasValue == false)
                {
                    thisItem.Priority = null;
                    thisItem.EnterStatus = EnumEnterStatus.Same; // Keep manual entries as they are
                }
                else if (thisItem.Priority.HasValue && thisItem.Previous.HasValue == false)
                {
                    thisItem.EnterStatus = EnumEnterStatus.NewItem;
                }
                else if (thisItem.Priority.HasValue && thisItem.Previous.HasValue)
                {
                    if (thisItem.Priority != thisItem.Previous)
                    {
                        thisItem.EnterStatus = EnumEnterStatus.Changed;
                    }
                    else
                    {
                        thisItem.EnterStatus = EnumEnterStatus.Same;
                    }
                }
            });
            //it shoud be impossible to have manual and new items at the same time.
            // Step 2: Sort the list based on priorities and EnterStatus (using the CompareTo logic)
            BasicList<E> newList = list.GetConditionalItems(items => items.Priority.HasValue).ToBasicList();
            newList.Sort();  // Sort based on the CompareTo method (Priority and EnterStatus)

            // Step 3: Handle manual entries that have been marked as 'Changed' or "Same'
            List<E> manualEntries = [.. newList.Where(item => item.EnterStatus != EnumEnterStatus.Same)];
            List<E> otherEntries = [.. newList.Where(item => item.EnterStatus == EnumEnterStatus.Same)];

            // Step 4: Ensure that manual entries maintain their manually set priorities and shift others around
            foreach (var manualEntry in manualEntries)
            {
                // If priority is manually set, it must stay where it was set
                int manualPriority = manualEntry.Priority!.Value;
                manualEntry.Priority = manualPriority;  // Ensure it remains the same
                manualEntry.Previous = manualPriority; // Keep the Previous value consistent
            }

            // Step 5: Adjust remaining entries that are not manually set
            int priorityCounter = 1;

            foreach (var entry in otherEntries)
            {
                // Skip priorities that are already taken by manual entries
                while (manualEntries.Any(me => me.Priority == priorityCounter))
                {
                    priorityCounter++;
                }

                entry.Priority = priorityCounter;
                entry.Previous = priorityCounter;
                priorityCounter++;
            }

            // Step 6: Combine manual and non-manual entries back together
            List<E> finalList = [.. manualEntries, .. otherEntries];

            // Step 7: Sort the entire list again, ensuring manual entries remain where they were manually set
            finalList.Sort();  // Use IComparable implementation to sort items

            // Step 8: Reassign sequential priorities starting from 1, ensuring null priorities are left alone
            int currentPriority = 1;
            finalList.ForEach(thisItem =>
            {
                if (thisItem.Priority.HasValue)  // Only reassign priority for items that have a valid priority
                {
                    thisItem.Priority = currentPriority;
                    thisItem.Previous = currentPriority;
                    currentPriority++;
                }
            });

            // Step 9: Re-assign final list back to the original list
            list.Clear();
            list.AddRange(finalList);
        }
    }
    
}