export const formToObject = (form) => form.find("input").get().reduce((obj, field) => {
    const { name, type, value, disabled } = field;

    if (!name || disabled || ['file', 'reset', 'submit', 'button'].indexOf(type) > -1) {
        return obj;
    }
    if (type === 'select-multiple') {
        let options = [];
        [...field.options].forEach(option => {
            if (!option.selected) {
                return obj;
            }
            options.push(option.value);
        });
        if (options.length) {
            obj[name] = options;
        }
        return obj;
    }
    if (type === 'number') {
        obj[name] = parseFloat(value);
        return obj;
    }
    if (['checkbox', 'radio'].indexOf(type) > -1) {
        if (!field.checked) {
            return obj;
        }
        if (value === 'true' && type === 'checkbox') {
            obj[name] = true;
            return obj;
        }
    }

    obj[name] = value;

    return obj;

}, {});

export const attachValidation = form => {
    
    const operationsCheckboxes = form.find(".operations:input:checkbox").get();
    
    let messages = {};
    let rules = {
        OperationsCount: {
            min: {
                param: 1
            },
            max: {
                param: 60
            }
        },
        Count : {
            min: {
                param: 1
            },
            max: {
                param: 0x7fffffff
            }
        }
    };
    let groups = {
        operationsGroup: operationsCheckboxes.map(el => el.name).join(' ')
    };

    operationsCheckboxes.forEach(checkbox => {
        rules[checkbox.name] = {
            require_from_group: [1, ".operations"]
        }
        messages[checkbox.name] = {
            require_from_group: "Select at least one operation type"
        }
    })
    
    console.log(messages, rules, groups);
    form.validate({
        rules,
        messages,
        groups,
        errorPlacement: (error, element) =>
            element.closest('form').append(error)
    }
    );
}