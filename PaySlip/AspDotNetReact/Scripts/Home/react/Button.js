import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import VehicleList from './VehicleList';
const styles = theme => ({
    button: {
        margin: theme.spacing.unit,
    },
    input: {
        display: 'none',
    },
});

function ContainedButtons(props) {
    const [initialized, setInitialized] = useState(false);
    const { classes } = props;
    const { OnButtonClick }=()=> {
        alert("hello");
    };
    useEffect(() => {
        if (initialized) {
            alert("llll");
        }
    });
    return (
        <div>

            <Button variant="contained" color="secondary" className={classes.button} onClick={() => alert("hello")}>
                Secondary
      </Button>
          
        </div>
    );
}

ContainedButtons.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(ContainedButtons);
