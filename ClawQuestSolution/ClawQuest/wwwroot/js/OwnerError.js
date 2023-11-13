document.addEventListener('DOMContentLoaded', function () {
    var form = document.querySelector('form');
    var inputs = document.querySelectorAll('.game-input');
    var maxSlots = 24;
    var errormessage = document.getElementById('error-message');

    function updateInputLimits() {
        var totalUsedSlots = Array.from(inputs).reduce(function (total, input) {
            return total + (parseInt(input.value) || 0);
        }, 0);

        var remainingSlots = maxSlots - totalUsedSlots;

        inputs.forEach(function (input) {
            var currentValue = parseInt(input.value) || 0;
            input.max = currentValue + remainingSlots;
        });
        if (totalUsedSlots > maxSlots) {
            errormessage.textContent = 'You can only select a total of 24 items.';
            errormessage.style.display = 'block';
        }
        else {
            errormessage.style.display = 'none';
        } 
    }

    inputs.forEach(function (input) {
        input.addEventListener('input', function () {
            updateInputLimits();
        });
    });

    form.addEventListener('submit', function (event) {
        var totalUsedSlots = Array.from(inputs).reduce(function (total, input) {
            return total + (parseInt(input.value) || 0);
    }, 0);
        if (totalUsedSlots > maxSlots) {
            event.preventDefault();
            errormessage.textContent = 'You can only select a total of 24 items.';
            errormessage.style.display = 'block';
        }
        else {
            errormessage.style.display = 'none';
        } 
        }
     });

    updateInputLimits();
});