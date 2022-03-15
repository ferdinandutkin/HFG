const formToObject = ({ elements }) => [...elements].reduce((obj, field) => {
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
    if (['checkbox', 'radio'].indexOf(field.type) > -1) {
        if (!field.checked) {
            return obj;
        }
        if (value === 'true' && type == 'checkbox') {
            obj[name] = true;
            return obj;
        }
    }

    obj[name] = value;

    return obj;

}, {});

